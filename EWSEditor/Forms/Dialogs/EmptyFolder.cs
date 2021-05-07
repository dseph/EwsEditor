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
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class EmptyFolder : Form
    {
        private Folder _Folder = null;

        public EmptyFolder()
        {
            InitializeComponent();
        }

        public EmptyFolder(Folder oFolder)
        {
            InitializeComponent();
            _Folder = oFolder;
        }

        private void EmptyFolder_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

            if (this.rdoHardDelete.Checked == true)
                 _Folder.Empty(DeleteMode.HardDelete, false);
            if (this.rdoHardDeleteAndIncludeSubfolders.Checked == true)
                 _Folder.Empty(DeleteMode.HardDelete, true);

            if (this.rdoSoftDelete.Checked == true)
                _Folder.Empty(DeleteMode.SoftDelete, false);
            if (this.rdoSoftDeleteAndIncludeSubfolders.Checked == true)
                _Folder.Empty(DeleteMode.SoftDelete, true);

            if (this.rdoMovetodeleteditmesfolder.Checked == true)
                _Folder.Empty(DeleteMode.MoveToDeletedItems, false);
            if (this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.Checked == true)
                _Folder.Empty(DeleteMode.MoveToDeletedItems, true);

            this.Close();
        }
    }
}
