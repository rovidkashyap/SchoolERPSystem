using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Inventory
{
    public class ItemCategory : AuditableEntity<int>
    {

        public string ItemCategoryName { get; set; }
        public string Description { get; set; }


    }
}
