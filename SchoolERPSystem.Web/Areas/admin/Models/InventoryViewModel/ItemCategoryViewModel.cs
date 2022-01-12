using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel
{
    public class ItemCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Item Category")]
        public string ItemCategoryName { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}