using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.AcademicsService.Interfaces;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.FrontOfficeControllers
{
    [Authorize(Roles = "Superadmin, Admin, Receptionist")]
    public class EnquiryController : Controller
    {
        IAdmissionEnquiryService _admissionEnquiryService;
        IReferencesService _referenceService;
        ISourceService _sourceService;
        ISchoolClassService _classService;

        public EnquiryController(IAdmissionEnquiryService admissionEnquiryService, IReferencesService referenceService, ISourceService sourceService, ISchoolClassService classService)
        {
            _admissionEnquiryService = admissionEnquiryService;
            _referenceService = referenceService;
            _sourceService = sourceService;
            _classService = classService;
        }

        // GET: admin/Enquiry
        public ActionResult Index(int? id)
        {
            AdmissionEnquiryViewModel viewmodel = new AdmissionEnquiryViewModel();
            if (id.HasValue && id != 0)
            {
                AdmissionEnquiry model = _admissionEnquiryService.GetById(id.Value);
                viewmodel.Address = model.Address;
                viewmodel.Assigned = model.Assigned;
                viewmodel.Date = model.Date;
                viewmodel.Description = model.Description;
                viewmodel.Email = model.Email;
                viewmodel.Name = model.Name;
                viewmodel.NextFollowUpDate = model.NextFollowUpDate;
                viewmodel.NoOfChild = model.NoOfChild;
                viewmodel.Note = model.Note;
                viewmodel.Phone = model.Phone;
                viewmodel.ReferenceId = model.ReferenceId;
                viewmodel.ReferenceName = model.ReferenceName.ReferenceName;
                viewmodel.SchoolClassId = model.SchoolClassId;
                viewmodel.SchoolClassName = model.SchoolClassName.ClassName;
                viewmodel.SourceId = model.SourceId;
                viewmodel.SourceName = model.SourceName.SourceName;
            }

            ViewBag.ReferenceId = new SelectList(_referenceService.GetAll(), "Id", "ReferenceName");
            ViewBag.SourceId = new SelectList(_sourceService.GetAll(), "Id", "SourceName");
            ViewBag.SchoolClassId = new SelectList(_classService.GetAll(), "Id", "ClassName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdmissionEnquiryViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                AdmissionEnquiry model = new AdmissionEnquiry
                {
                    Address = viewmodel.Address,
                    Assigned = viewmodel.Assigned,
                    Date = viewmodel.Date,
                    Description = viewmodel.Description,
                    Email = viewmodel.Email,
                    Name = viewmodel.Name,
                    NextFollowUpDate = viewmodel.NextFollowUpDate,
                    NoOfChild = viewmodel.NoOfChild,
                    Note = viewmodel.Note,
                    Phone = viewmodel.Phone,
                    ReferenceId = viewmodel.ReferenceId,
                    SchoolClassId = viewmodel.SchoolClassId,
                    SourceId = viewmodel.SourceId,
                    Id = viewmodel.Id
                };

                _admissionEnquiryService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.ReferenceId = new SelectList(_referenceService.GetAll(), "Id", "ReferenceName", model.ReferenceId);
                    ViewBag.SourceId = new SelectList(_sourceService.GetAll(), "Id", "SourceName", model.SourceId);
                    ViewBag.SchoolClassId = new SelectList(_classService.GetAll(), "Id", "ClassName", model.SchoolClassId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                AdmissionEnquiry model = _admissionEnquiryService.GetById(viewmodel.Id);
                model.Address = viewmodel.Address;
                model.Assigned = viewmodel.Assigned;
                model.Date = viewmodel.Date;
                model.Description = viewmodel.Description;
                model.Email = viewmodel.Email;
                model.Name = viewmodel.Name;
                model.NextFollowUpDate = viewmodel.NextFollowUpDate;
                model.NoOfChild = viewmodel.NoOfChild;
                model.Note = viewmodel.Note;
                model.Phone = viewmodel.Phone;
                model.ReferenceId = viewmodel.ReferenceId;
                model.SchoolClassId = viewmodel.SchoolClassId;
                model.SourceId = viewmodel.SourceId;

                _admissionEnquiryService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Enquiry", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<AdmissionEnquiryViewModel> viewmodel = _admissionEnquiryService.GetAll().Select(a => new AdmissionEnquiryViewModel
            {
                Address = a.Address,
                Date = a.Date,
                Assigned = a.Assigned,
                Description = a.Description,
                Email = a.Email,
                Id = a.Id,
                Name = a.Name,
                NextFollowUpDate = a.NextFollowUpDate,
                NoOfChild = a.NoOfChild,
                Note = a.Note,
                Phone = a.Phone,
                ReferenceId = a.ReferenceId,
                ReferenceName = a.ReferenceName.ReferenceName,
                SchoolClassId = a.SchoolClassId,
                SchoolClassName = a.SchoolClassName.ClassName,
                SourceId = a.SourceId,
                SourceName = a.SourceName.SourceName
            });

            return View(viewmodel);
        }
    }
}