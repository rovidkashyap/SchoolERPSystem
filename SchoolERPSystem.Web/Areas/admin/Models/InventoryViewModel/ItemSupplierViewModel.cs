using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel
{
    public class ItemSupplierViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Contact Person Name")]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person Phone")]
        public string ContactPersonPhone { get; set; }

        [Display(Name = "Contact Person Email")]
        public string ContactPersonEmail { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}