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
    public class VisitorBookController : Controller
    {
        IPurposeService _purposeService;
        IVisitorDetailsService _visitorDetailsService;

        public VisitorBookController(IVisitorDetailsService visitorDetailsService, IPurposeService purposeService)
        {
            _visitorDetailsService = visitorDetailsService;
            _purposeService = purposeService;
        }

        // GET: admin/VisitorBook
        public ActionResult Index(int? id)
        {
            VisitorBookViewModel viewmodel = new VisitorBookViewModel();
            if (id.HasValue && id != 0)
            {
                VisitorDetails model = _visitorDetailsService.GetById(id.Value);
                viewmodel.PurposeName = model.PurposeName.PurposeName;
                viewmodel.DocumentSubmitted = model.DocumentSubmitted;
                viewmodel.FullName = model.FullName;
                viewmodel.IdentiyCardNumber = model.IdentiyCardNumber;
                viewmodel.InTime = model.InTime;
                viewmodel.NoOfPerson = model.NoOfPerson;
                viewmodel.Note = model.Note;
                viewmodel.OutTime = model.OutTime;
                viewmodel.Phone = model.Phone;
                viewmodel.PurposeId = model.PurposeId;
                viewmodel.VisitingDate = DateTime.Now;
            }

            ViewBag.PurposeId = new SelectList(_purposeService.GetAll(), "Id", "PurposeName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VisitorBookViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                VisitorDetails model = new VisitorDetails
                {
                    DocumentSubmitted = viewmodel.DocumentSubmitted,
                    FullName = viewmodel.FullName,
                    IdentiyCardNumber = viewmodel.IdentiyCardNumber,
                    InTime = viewmodel.InTime,
                    NoOfPerson = viewmodel.NoOfPerson,
                    OutTime = viewmodel.OutTime,
                    PurposeId = viewmodel.PurposeId,
                    VisitingDate = viewmodel.VisitingDate,
                    Phone = viewmodel.Phone,
                    Id = viewmodel.Id
                };
                _visitorDetailsService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.PurposeId = new SelectList(_visitorDetailsService.GetAll(), "Id", "PurposeName", model.PurposeId);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                VisitorDetails model = _visitorDetailsService.GetById(viewmodel.Id);
                model.DocumentSubmitted = viewmodel.DocumentSubmitted;
                model.FullName = viewmodel.FullName;
                model.IdentiyCardNumber = viewmodel.IdentiyCardNumber;
                model.InTime = viewmodel.InTime;
                model.NoOfPerson = viewmodel.NoOfPerson;
                model.OutTime = viewmodel.OutTime;
                model.PurposeId = viewmodel.PurposeId;
                model.VisitingDate = viewmodel.VisitingDate;
                model.Phone = viewmodel.Phone;

                _visitorDetailsService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "VisitorBook", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<VisitorBookViewModel> viewmodel = _visitorDetailsService.GetAll().Select(s => new VisitorBookViewModel
            {
                DocumentSubmitted = s.DocumentSubmitted,
                FullName = s.FullName,
                IdentiyCardNumber = s.IdentiyCardNumber,
                InTime = s.InTime,
                NoOfPerson = s.NoOfPerson,
                OutTime = s.OutTime,
                PurposeId = s.PurposeId,
                Phone = s.Phone,
                PurposeName = s.PurposeName.PurposeName,
                VisitingDate = s.VisitingDate,
                Id = s.Id
            });
            return View(viewmodel);
        }
    }
}