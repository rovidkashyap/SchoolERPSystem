using SchoolERPSystem.Service.StaffModelService.Interfaces;
using SchoolERPSystem.Service.StudentModelService.Interfaces;
using SchoolERPSystem.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers
{
    public class DashboardController : Controller
    {
        IStaffProfileService _staffProfileService;
        IStudentAdmissionService _studentAdmissionService;

        public DashboardController(IStaffProfileService staffProfileService, IStudentAdmissionService studentAdmissionService)
        {
            _staffProfileService = staffProfileService;
            _studentAdmissionService = studentAdmissionService;
        }

        // GET: admin/Dashboard
        public ActionResult Index()
        {
            int adminCount = _staffProfileService.GetCountByRoleName("Admin");
            int superadminCount = _staffProfileService.GetCountByRoleName("Superadmin");
            int accountantCount = _staffProfileService.GetCountByRoleName("Accountant");
            int librarianCount = _staffProfileService.GetCountByRoleName("Librarian");
            int teacherCount = _staffProfileService.GetCountByRoleName("Teacher");
            int receptionistCount = _staffProfileService.GetCountByRoleName("Receptionist");

            int studentCount = _studentAdmissionService.StudentCount();

            StaffProfileViewModel staffProfile = new StaffProfileViewModel
            {
                superadminCount = superadminCount,
                adminCount = adminCount,
                teacherCount = teacherCount,
                librarianCount = librarianCount,
                accountantCount = accountantCount,
                receptionistCount = receptionistCount,
                studentCount = studentCount
            };

            return View(staffProfile);
        }
    }
}