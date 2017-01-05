using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;

namespace EWSEditor.Common
{
    public class ItemTag
    {
        private ItemId _Id = null;
        private string _ItemClass = string.Empty;
 

        public ItemTag(ItemId oID, string ItemClass ) 
        {
            _Id = oID;
            _ItemClass = ItemClass;
            
        }

        public string ItemClass
        {
            get { return _ItemClass; }
            set { _ItemClass = value; }
        }

        public ItemId Id
        {
            get { return _Id; }
            set { _Id = value; }

        }
 
    }

    public class CalendarItemTag
    {
        private ItemId _Id = null;
        //private bool _IsRecurring = false;
        private string _ItemUid = string.Empty;
        private string _ItemClass = string.Empty;

        //public CalendarItemTag(ItemId oID, bool IsRecurring, string ItemClass, string ItemUid)
        public CalendarItemTag(ItemId oID, string ItemClass, string ItemUid)
        {
            _Id = oID;
            //_IsRecurring = IsRecurring;
            _ItemClass = ItemClass;
            _ItemUid = ItemUid;
        }

        //public bool IsRecurring
        //{
        //    get { return _IsRecurring; }
        //    set { _IsRecurring = value; }
        //}

        public ItemId Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string ItemUid
        {
            get { return _ItemUid; }
            set { _ItemUid = value; }

        }

        public string ItemClass
        {
            get { return _ItemClass; }
            set { _ItemClass = value; }
        }
    }
}
