using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers
{
    public class CallLogController : Controller
    {
        IPhoneCallLogService _PhoneCallLogService;

        public CallLogController(IPhoneCallLogService PhoneCallLogService)
        {
            _PhoneCallLogService = PhoneCallLogService;
        }

        // GET: admin/PhoneCallLog
        [HttpGet]
        public ActionResult Index(int? id)
        {
            PhoneCallLogViewModel viewmodel = new PhoneCallLogViewModel();
            if (id.HasValue && id != 0)
            {
                PhoneCallLog model = _PhoneCallLogService.GetById(id.Value);
                viewmodel.CallDuration = model.CallDuration;
                viewmodel.CallType = model.CallType;
                viewmodel.Date = DateTime.Now;
                viewmodel.Description = model.Description;
                viewmodel.Name = model.Name;
                viewmodel.NextDate = model.NextDate;
                viewmodel.Note = model.Note;
                viewmodel.Phone = model.Phone;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PhoneCallLogViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                PhoneCallLog model = new PhoneCallLog
                {
                    CallDuration = viewmodel.CallDuration,
                    CallType = viewmodel.CallType,
                    Date = viewmodel.Date,
                    Description = viewmodel.Description,
                    Name = viewmodel.Name,
                    NextDate = viewmodel.NextDate,
                    Note = viewmodel.Note,
                    Phone = viewmodel.Phone,
                    Id = viewmodel.Id
                };

                _PhoneCallLogService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                PhoneCallLog model = _PhoneCallLogService.GetById(viewmodel.Id);
                model.CallDuration = viewmodel.CallDuration;
                model.CallType = viewmodel.CallType;
                model.Date = viewmodel.Date;
                model.Description = viewmodel.Description;
                model.Name = viewmodel.Name;
                model.NextDate = viewmodel.NextDate;
                model.Note = viewmodel.Note;
                model.Phone = viewmodel.Phone;

                _PhoneCallLogService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "CallLog", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<PhoneCallLogViewModel> viewmodel = _PhoneCallLogService.GetAll().Select(p => new PhoneCallLogViewModel
            {
                CallDuration = p.CallDuration,
                CallType = p.CallType,
                Date = p.Date,
                Description = p.Description,
                Name = p.Name,
                NextDate = p.NextDate,
                Note = p.Note,
                Phone = p.Phone,
                Id = p.Id
            });
            return View(viewmodel);
        }
    }
}