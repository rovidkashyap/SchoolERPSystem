using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.TransportViewModel
{
    public class VehicleRouteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Route")]
        public int RouteId { get; set; }

        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        [Display(Name = "Route")]
        public string Route { get; set; }

        [Display(Name = "Vehicle")]
        public string Vehicle { get; set; }
    }
}