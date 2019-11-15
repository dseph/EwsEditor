using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class ResolveNameForm : ItemsContentForm
    {
        private const string colNameDisplayName = "colDisplayName";
        private const string colNameMailboxName = "colMailboxName";
        private const string colNameAddress = "colAddress";
        private const string colNameMailboxType = "colMailboxType";
        private const string colNameRoutingType = "colRoutingType";
        private const string colNameDirectoryId = "colDirectoryId";
        private const string colNameUniqueId = "colUniqueId";

        private const string colNameContentId = "colContentId";

        public ResolveNameForm()
        {
            InitializeComponent();
        }

        public static void Show(ExchangeService service, Form parentForm)
        {
            ResolveNameForm form = new ResolveNameForm();

            form.CurrentService = service;
            form.PropertyDetailsGrid.CurrentService = service;
            form.Text = "Resolve Name";
            form.CallingForm = parentForm;
            form.Show();
        }

        protected override void SetupForm()
        {
            base.SetupForm();
            ContentsGrid.Columns.Clear();
            var cols = ContentsGrid.Columns;
            int col;
            col = cols.Add(colNameDisplayName, "DisplayName");
            cols[col].Width = 175;
            col = cols.Add(colNameMailboxName, "Mailbox.Name");
            cols[col].Width = 175;
            col = cols.Add(colNameAddress, "Mailbox.Address");
            cols[col].Width = 175;
            
            col = cols.Add(colNameMailboxType, "MailboxType");
            cols[col].Width = 75;
            col = cols.Add(colNameRoutingType, "RoutingType");
            cols[col].Width = 75;
            col = cols.Add(colNameDirectoryId, "DirectoryId");
            cols[col].Width = 260;
            col = cols.Add(colNameUniqueId, "ItemId");
            cols[col].Width = 500;

            col = cols.Add(colNameContentId, "----");
            cols[col].Visible = false;

            ContentIdColumnName = colNameContentId;
        }

        protected override void LoadContents()
        {
            if (txtName.Text.Length == 0)
                return;

            ResolveNameSearchLocation oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsThenDirectory;
            switch (cmboResolveNameSearchLocation.Text)
            {
                case "DirectoryOnly":
                    oResolveNameSearchLocation = ResolveNameSearchLocation.DirectoryOnly;
                    break;
                case "DirectoryThenContacts":
                    oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsThenDirectory;
                    break;
                case "ContactsOnly":
                    oResolveNameSearchLocation = ResolveNameSearchLocation.ContactsOnly;
                    break;
                case "ContactsThenDirectory":
                    oResolveNameSearchLocation = ResolveNameSearchLocation.DirectoryThenContacts;
                    break;
            }

            NameResolutionCollection oNameResolutionCollection = CurrentService.ResolveName(
                txtName.Text,
                oResolveNameSearchLocation,
                chkReturnContactDetails.Checked,
                PropertySet.FirstClassProperties
            );

            Dictionary<string, string> itemIdToDisplayName = new Dictionary<string, string>();
            ItemId[] toLookup = oNameResolutionCollection
                .Where(nr => nr.Contact == null && nr.Mailbox.Id != null)
                .Select(nr => nr.Mailbox.Id)
                .ToArray();
            if (toLookup.Length > 0)
            {
                var itemsWithDisplayNames =
                    CurrentService.BindToItems(toLookup, new PropertySet(BasePropertySet.IdOnly, ContactSchema.DisplayName));
                foreach (GetItemResponse resp in itemsWithDisplayNames)
                {
                    if (resp.Result != ServiceResult.Error && resp.Item != null &&
                        resp.Item.TryGetProperty(ContactSchema.DisplayName, out string displayName))
                    {
                        itemIdToDisplayName[resp.Item.Id.UniqueId] = displayName;
                    }
                }
            }

            // Load new results
            foreach (NameResolution name in oNameResolutionCollection)
            {
                int rowIdx = ContentsGrid.Rows.Add();
                DataGridViewRow row = ContentsGrid.Rows[rowIdx];
                string displayName = null;
                if (name.Contact != null)
                    name.Contact.TryGetProperty(ContactSchema.DisplayName, out displayName);
                if (displayName == null && name.Mailbox.Id != null)
                    itemIdToDisplayName.TryGetValue(name.Mailbox.Id.UniqueId, out displayName);
                if (displayName != null)
                    row.Cells[colNameDisplayName].Value = displayName;

                row.Cells[colNameMailboxName].Value = name.Mailbox.Name;
                row.Cells[colNameAddress].Value = name.Mailbox.Address;
                row.Cells[colNameMailboxType].Value = name.Mailbox.MailboxType;
                row.Cells[colNameRoutingType].Value = name.Mailbox.RoutingType;
                if (name.Mailbox.Id != null)
                {
                    row.Cells[colNameUniqueId].Value = name.Mailbox.Id.UniqueId;
                    row.Cells[colNameContentId].Value = name.Mailbox.Id.UniqueId;
                }
                if (name.Contact != null && name.Contact.TryGetProperty(ContactSchema.DirectoryId, out string directoryId))
                {
                    row.Cells[colNameDirectoryId].Value = directoryId;
                    row.Cells[colNameContentId].Value = directoryId;
                }
                row.Tag = name;
            }
        }
        

        protected override void LoadSelectionDetails()
        {
            // Only load details if a content row is selected
            if (ContentsGrid.SelectedRows.Count == 0)
                return;

            PropertyDetailsGrid.Clear();
            NameResolution nr = (NameResolution)ContentsGrid.SelectedRows[0].Tag;
            if (nr == null)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                if (nr.Contact != null)
                {
                    PropertyDetailsGrid.LoadObject(nr.Contact);
                }
                else if (nr.Mailbox.Id != null)
                {
                    Item details = Item.Bind(CurrentService, nr.Mailbox.Id, CurrentDetailPropertySet);
                    PropertyDetailsGrid.LoadObject(details);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshContentAndDetails();
        }
    }
}
