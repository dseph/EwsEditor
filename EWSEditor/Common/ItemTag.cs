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
        public ItemTag(ItemId oID, string ItemClass)
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
        private bool _IsRecurring = false;
        public CalendarItemTag(ItemId oID, bool IsRecurring)
        {
            _Id = oID;
            _IsRecurring = IsRecurring;
        }

        public bool IsRecurring
        {
            get { return _IsRecurring; }
            set { _IsRecurring = value; }
        }

        public ItemId Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
