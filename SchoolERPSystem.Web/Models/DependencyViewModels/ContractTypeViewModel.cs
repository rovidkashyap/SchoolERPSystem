using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Models.DependencyViewModels
{
    public class ContractTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Contract Type Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DisplayFormat(NullDisplayText = "--")]
        public string Description { get; set; }
    }
}