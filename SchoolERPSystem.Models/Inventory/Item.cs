using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Inventory
{
    public class Item : AuditableEntity<int>
    {

        public string ItemName { get; set; }
        public int ItemCategoryId { get; set; }
        public string Description { get; set; }

        public ItemCategory ItemCategory { get; set; }

    }
}
