using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel
{
    public class ItemStoreViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Item Store Name")]
        public string ItemStoreName { get; set; }

        [Display(Name = "Item Stock Code")]
        public string ItemStockCode { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}