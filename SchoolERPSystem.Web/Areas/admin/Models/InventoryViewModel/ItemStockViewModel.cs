using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel
{
    public class ItemStockViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Item Category")]
        public int ItemCategoryId { get; set; }

        [Display(Name = "Item")]
        public int ItemId { get; set; }

        [Display(Name = "Supplier")]
        public int ItemSupplierId { get; set; }

        [Display(Name = "Store")]
        public int ItemStoreId { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Date")]
        public DateTime? Date { get; set; }

        [Display(Name = "Attach Document")]
        public string Document { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemSupplier { get; set; }
        public string ItemStore { get; set; }
    }
}