//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using EWSEditor.Common;
//using EWSEditor.Exchange;
//using EWSEditor.Logging;
//using EWSEditor.Resources;
//using EWSEditor.Settings;
//using Microsoft.Exchange.WebServices.Data;

//namespace EWSEditor.Common
//{

//    class PropertyGridHelper
//    {
//        //private System.Windows.Forms.ContextMenuStrip mnuItemContext;
//        //this.mnuItemContext = new System.Windows.Forms.ContextMenuStrip(this.components);

//        protected const string ColNameSubject = "colSubject";
//        protected const string ColNameDisplayTo = "colDisplayTo";
//        protected const string ColNameItemClass = "colItemClass";
//        protected const string ColNameSize = "colSize";
//        protected const string ColNameHasAttach = "colHasAttachments";
//        protected const string ColNameDateReceived = "colDateReceived";
//        protected const string ColNameDateCreated = "colDateCreated";
//        protected const string ColNameDateSent = "colDateSent";
//        protected const string ColNameLastModifiedTime = "colLastModifiedTime";
//        protected const string ColNameLastModifiedName = "colLastModifiedName";
//        protected const string ColNameIsAssociated = "colIsAssociated";
//        protected const string ColNameSensitivity = "colSensitivity";
//        protected const string ColNameDisplayCc = "colDisplayCC";
//        protected const string ColNameCategories = "colCategories";
//        protected const string ColNameCulture = "colCulture";
//        protected const string ColNameItemId = "colItemId";

//        private List<ItemId> currentItemIds = new List<ItemId>();
//        private ItemView contentItemView = new ItemView(GlobalSettings.FindItemViewSize);


//        protected void InitGrid(ref DataGridView oDataGridView)
//        {
//            // Setup the oDataGridView with columns for displaying item collections
//            int col = 0;
//            col = oDataGridView.Columns.Add(ColNameSubject, "Subject");
//            oDataGridView.Columns[col].Width = 175;

//            col = oDataGridView.Columns.Add(ColNameDisplayTo, "DisplayTo");
//            oDataGridView.Columns[col].Width = 125;

//            col = oDataGridView.Columns.Add(ColNameItemClass, "ItemClass");
//            oDataGridView.Columns[col].Width = 175;

//            col = oDataGridView.Columns.Add(ColNameSize, "Size");
//            oDataGridView.Columns[col].Width = 50;

//            col = oDataGridView.Columns.Add(ColNameHasAttach, "HasAttachments");
//            oDataGridView.Columns[col].Width = 50;

//            col = oDataGridView.Columns.Add(ColNameDateReceived, "DateTimeReceived");
//            oDataGridView.Columns[col].ValueType = typeof(DateTime);
//            oDataGridView.Columns[col].Width = 150;

//            col = oDataGridView.Columns.Add(ColNameDateCreated, "DateTimeCreated");
//            oDataGridView.Columns[col].ValueType = typeof(DateTime);
//            oDataGridView.Columns[col].Width = 150;

//            col = oDataGridView.Columns.Add(ColNameDateSent, "DateTimeSent");
//            oDataGridView.Columns[col].ValueType = typeof(DateTime);
//            oDataGridView.Columns[col].Width = 150;

//            col = oDataGridView.Columns.Add(ColNameLastModifiedTime, "LastModifiedTime");
//            oDataGridView.Columns[col].ValueType = typeof(DateTime);
//            oDataGridView.Columns[col].Width = 150;

//            col = oDataGridView.Columns.Add(ColNameLastModifiedName, "LastModifiedName");
//            oDataGridView.Columns[col].Width = 125;

//            col = oDataGridView.Columns.Add(ColNameIsAssociated, "IsAssociated");
//            oDataGridView.Columns[col].Width = 75;

//            col = oDataGridView.Columns.Add(ColNameSensitivity, "Sensitivity");
//            oDataGridView.Columns[col].Width = 75;

//            col = oDataGridView.Columns.Add(ColNameDisplayCc, "DisplayCC");
//            oDataGridView.Columns[col].Width = 125;

//            col = oDataGridView.Columns.Add(ColNameCategories, "Categories");
//            oDataGridView.Columns[col].Width = 150;

//            col = oDataGridView.Columns.Add(ColNameCulture, "Culture");
//            oDataGridView.Columns[col].Width = 50;

//            col = oDataGridView.Columns.Add(ColNameItemId, "ItemId");
//            oDataGridView.Columns[col].Visible = false;
 
//        }


//        /// <summary>
//        /// Add the given item to the ContentsGrid
//        /// </summary>
//        /// <param name="item">Item to add</param>
//        protected void AddContentItem(Item item, ref DataGridView oDataGridView)
//        {
//            // TODO: Add Try/Catch blocks
//            int row = oDataGridView.Rows.Add();
//            oDataGridView.Rows[row].Cells[ColNameSubject].Value = item.Subject;
//            oDataGridView.Rows[row].Cells[ColNameDisplayTo].Value = item.DisplayTo;
//            oDataGridView.Rows[row].Cells[ColNameItemClass].Value = item.ItemClass;
//            oDataGridView.Rows[row].Cells[ColNameSize].Value = item.Size;
//            oDataGridView.Rows[row].Cells[ColNameHasAttach].Value = item.HasAttachments;

//            try
//            {
//                oDataGridView.Rows[row].Cells[ColNameDateReceived].Value = item.DateTimeReceived.ToString();
//            }
//            catch (Exception ex)
//            {
//                DebugLog.WriteVerbose("Handled exception when getting DateTimeReceived", ex);
//                oDataGridView.Rows[row].Cells[ColNameDateReceived].Value = ex.Message;
//            }

//            oDataGridView.Rows[row].Cells[ColNameDateCreated].Value = item.DateTimeCreated.ToString();

//            try
//            {
//                oDataGridView.Rows[row].Cells[ColNameDateSent].Value = item.DateTimeSent.ToString();
//            }
//            catch (Exception ex)
//            {
//                DebugLog.WriteVerbose("Handled exception when getting DateTimeSent", ex);
//                oDataGridView.Rows[row].Cells[ColNameDateSent].Value = ex.Message;
//            }

//            oDataGridView.Rows[row].Cells[ColNameLastModifiedTime].Value = item.LastModifiedTime.ToString();
//            oDataGridView.Rows[row].Cells[ColNameLastModifiedName].Value = item.LastModifiedName;

//            try
//            {
//                oDataGridView.Rows[row].Cells[ColNameIsAssociated].Value = item.IsAssociated;
//            }
//            catch (Exception ex)
//            {
//                DebugLog.WriteVerbose("Handled exception when getting IsAssociated", ex);
//                oDataGridView.Rows[row].Cells[ColNameIsAssociated].Value = ex.Message;
//            }

//            oDataGridView.Rows[row].Cells[ColNameSensitivity].Value = item.Sensitivity;
//            oDataGridView.Rows[row].Cells[ColNameDisplayCc].Value = item.DisplayCc;
//            oDataGridView.Rows[row].Cells[ColNameCategories].Value = item.Categories;

//            try
//            {
//                oDataGridView.Rows[row].Cells[ColNameCulture].Value = item.Culture;
//            }
//            catch (Exception ex)
//            {
//                DebugLog.WriteVerbose("Handled exception when getting Culture", ex);
//                oDataGridView.Rows[row].Cells[ColNameCulture].Value = ex.Message;
//            }

//            oDataGridView.Rows[row].Cells[ColNameItemId].Value = item.Id.UniqueId;
//            oDataGridView.Rows[row].ContextMenuStrip = this.mnuItemContext;
//        }

//    }
//}
