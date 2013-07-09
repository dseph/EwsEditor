using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common
{
    public class FolderTag
    {
        private FolderId _Id = null;
        private string _FolderClass = string.Empty;
        public FolderTag(FolderId Id, string FolderClass)
        {
            _Id = Id;
            _FolderClass = FolderClass;
        }
        public string FolderClass
        {
            get { return _FolderClass; }
            set { _FolderClass = value; }
        }
        public FolderId Id
        {
            get { return _Id; }
            set { _Id = value; }

        }

    }
}
