using SchoolERPSystem.Service;
using SchoolERPSystem.Web.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers
{
    [Authorize]
    public class UserlogController : Controller
    {
        IUserLogService _userlogService;

        public UserlogController(IUserLogService userlogService)
        {
            _userlogService = userlogService;
        }

        // GET: admin/Userlog
        public ActionResult Index()
        {
            IEnumerable<UserlogViewModel> model = _userlogService.GetAll().Select(u => new UserlogViewModel
            {
                IPAddress = u.IPAddress,
                Username = u.Username,
                Email = u.Email,
                MemberRoleName = u.RoleName,
                LoginDate = u.LoginDate,
                UserAgent = u.UserAgent,
                Id = u.Id
            });
            return View(model);
        }
    }
}