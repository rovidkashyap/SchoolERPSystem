using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models.Inventory
{
    public class ItemStock : AuditableEntity<int>
    {
        public int ItemCategoryId { get; set; }
        public int ItemId { get; set; }
        public int ItemSupplierId { get; set; }
        public int ItemStoreId { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }

        public ItemCategory ItemCategory { get; set; }
        public Item Item { get; set; }
        public ItemSupplier ItemSupplier { get; set; }
        public ItemStore ItemStore { get; set; }

        

        
    }
}
