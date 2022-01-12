using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Item")]
        public string ItemName { get; set; }

        [Display(Name = "Item Category")]
        public int ItemCategoryId { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ItemCategory { get; set; }
    }
}