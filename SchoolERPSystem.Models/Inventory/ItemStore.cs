using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Inventory
{
    public class ItemStore : AuditableEntity<int>
    {
        public string ItemStoreName { get; set; }
        public string ItemStockCode { get; set; }
        public string Description { get; set; }

    }
}
