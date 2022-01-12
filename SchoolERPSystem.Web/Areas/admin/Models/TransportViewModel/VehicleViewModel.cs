using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.TransportViewModel
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Number")]
        public string VehicleNumber { get; set; }

        [Display(Name = "Vehicle Model")]
        public string VehicleModel { get; set; }

        [Display(Name = "Year Made")]
        public string YearMade { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Driver License")]
        public string DriverLicense { get; set; }

        [Display(Name = "Driver Contact")]
        public string DriverContact { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }
    }
}