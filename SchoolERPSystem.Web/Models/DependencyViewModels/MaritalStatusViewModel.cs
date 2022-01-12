using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels
{
    public class MaritalStatusViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string Name { get; set; }
    }
}