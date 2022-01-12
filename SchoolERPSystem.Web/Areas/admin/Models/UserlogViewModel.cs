using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolERPSystem.Web.Areas.admin.Models
{
    public class UserlogViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string IPAddress { get; set; }
        public DateTime LoginDate { get; set; }
        public int MemberRoleId { get; set; }
        public string MemberRoleName { get; set; }
        public string UserAgent { get; set; }
        public string ApplicationUserId { get; set; }
    }
}