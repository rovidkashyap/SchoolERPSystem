using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels
{
    public class GenderViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Name { get; set; }
    }
}