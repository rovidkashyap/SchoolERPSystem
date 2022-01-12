using PagedList;
using SchoolERPSystem.Models;
using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Service.StaffModelService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.HRViewModel;
using SchoolERPSystem.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.HRControllers
{
    public class StaffAttendanceController : Controller
    {
        IStaffAttendanceService _staffAttendanceService;
        IStaffProfileService _staffProfileService;

        public StaffAttendanceController(IStaffAttendanceService staffAttendanceService, IStaffProfileService staffProfileService)
        {
            _staffAttendanceService = staffAttendanceService;
            _staffProfileService = staffProfileService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<StaffAttendanceViewModel> viewmodel = _staffProfileService.GetAll().Select(s => new StaffAttendanceViewModel
            {
                StaffProfileId = s.Id
            });

            ViewBag.StaffProfileId = new SelectList(_staffProfileService.GetAll(), "Id", "StaffId");
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(StaffAttendanceViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                StaffAttendance model = new StaffAttendance
                {
                    Id = viewmodel.Id,
                    StaffProfileId = viewmodel.StaffProfileId,
                    Attendance = viewmodel.Attendance,
                    AttendanceDate = viewmodel.AttendanceDate,
                    IsHoliday = viewmodel.IsHoliday,
                    Note = viewmodel.Note
                };

                _staffAttendanceService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.StaffProfileId = new SelectList(_staffProfileService.GetAll(), "Id", "StaffId", viewmodel.StaffProfileId);
            return View(viewmodel);
        }
  
    }
}