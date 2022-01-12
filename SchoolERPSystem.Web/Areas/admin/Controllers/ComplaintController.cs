using SchoolERPSystem.Models.Authentication;
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
    [Authorize(Roles = "Superadmin, Admin, Receptionist")]
    public class ComplaintController : Controller
    {
        IComplaintService _complaintService;
        IComplaintTypeService _complaintTypeService;
        ISourceService _sourceService;

        public ComplaintController(IComplaintService complaintService, IComplaintTypeService complaintTypeService, ISourceService sourceService)
        {
            _complaintService = complaintService;
            _complaintTypeService = complaintTypeService;
            _sourceService = sourceService;
        }

        // GET: admin/Complaint
        [HttpGet]
        public ActionResult Index(int? id)
        {
            ComplaintViewModel viewmodel = new ComplaintViewModel();
            if (id.HasValue && id != 0)
            {
                ComplainDetails model = _complaintService.GetById(id.Value);
                viewmodel.ActionTaken = model.ActionTaken;
                viewmodel.Assigned = model.Assigned;
                viewmodel.ComplainBy = model.ComplainBy;
                viewmodel.ComplainDate = model.ComplainDate;
                viewmodel.ComplainTypeId = model.ComplainTypeId;
                viewmodel.ComplainType = model.ComplainType.ComplainName;
                viewmodel.Description = model.Description;
                viewmodel.Documents = model.Documents;
                viewmodel.Note = model.Note;
                viewmodel.Phone = model.Phone;
                viewmodel.SourceId = model.SourceId;
                viewmodel.Source = model.Source.SourceName;
            }

            ViewBag.ComplaintTypeId = new SelectList(_complaintTypeService.GetAll(), "Id", "ComplainName");
            ViewBag.SourceId = new SelectList(_sourceService.GetAll(), "Id", "SourceName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ComplaintViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ComplainDetails model = new ComplainDetails
                {
                    ActionTaken = viewmodel.ActionTaken,
                    Assigned = viewmodel.Assigned,
                    ComplainBy = viewmodel.ComplainBy,
                    ComplainDate = viewmodel.ComplainDate,
                    ComplainTypeId = viewmodel.ComplainTypeId,
                    Description = viewmodel.Description,
                    Documents = viewmodel.Documents,
                    Note = viewmodel.Note,
                    Phone = viewmodel.Phone,
                    SourceId = viewmodel.SourceId,
                    Id = viewmodel.Id,
                    IsActive = true

                };
                _complaintService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.ComplaintTypeId = new SelectList(_complaintTypeService.GetAll(), "Id", "ComplainName", model.ComplainTypeId);
                    ViewBag.SourceId = new SelectList(_sourceService.GetAll(), "Id", "SourceName", model.SourceId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ComplainDetails model = _complaintService.GetById(viewmodel.Id);
                model.ActionTaken = viewmodel.ActionTaken;
                model.Assigned = viewmodel.Assigned;
                model.ComplainBy = viewmodel.ComplainBy;
                model.ComplainDate = viewmodel.ComplainDate;
                model.ComplainTypeId = viewmodel.ComplainTypeId;
                model.Description = viewmodel.Description;
                model.Documents = viewmodel.Documents;
                model.Note = viewmodel.Note;
                model.Phone = viewmodel.Phone;
                model.SourceId = viewmodel.SourceId;

                _complaintService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Complaint", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ComplaintViewModel> viewmodel = _complaintService.GetAll().Select(s => new ComplaintViewModel
            {
                ActionTaken = s.ActionTaken,
                Assigned = s.Assigned,
                ComplainBy = s.ComplainBy,
                ComplainType = s.ComplainType.ComplainName,
                ComplainDate = s.ComplainDate,
                ComplainTypeId = s.ComplainTypeId,
                Description = s.Description,
                Documents = s.Documents,
                Note = s.Note,
                Phone = s.Phone,
                SourceId = s.SourceId,
                Source = s.Source.SourceName,
                Id = s.Id
            });
            return View(viewmodel);
        }
    }
}