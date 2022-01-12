using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.TransportViewModel
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Route Title")]
        public string RouteTitle { get; set; }

        [Display(Name = "Fare")]
        public decimal Fare { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}