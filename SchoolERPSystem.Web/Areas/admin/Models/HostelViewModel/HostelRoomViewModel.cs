using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel
{
    public class HostelRoomViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Room Number / Name")]
        public string RoomNumberOrName { get; set; }

        [Display(Name = "Hostel")]
        public int HostelId { get; set; }

        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Number Of Bed")]
        public int NoOfBed { get; set; }

        [Display(Name = "Cost Per Bed")]
        public decimal CostPerBed { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Hostel")]
        public string Hostel { get; set; }

        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
    }
}