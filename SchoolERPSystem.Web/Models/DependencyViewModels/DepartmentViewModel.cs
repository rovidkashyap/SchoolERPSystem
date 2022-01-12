using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}