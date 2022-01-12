using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Room Type")]
        public string RoomTypeName { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}