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
    public class ComplainTypeController : Controller
    {
        IComplaintTypeService _complaintTypeService;

        public ComplainTypeController(IComplaintTypeService complaintTypeService)
        {
            _complaintTypeService = complaintTypeService;
        }

        // GET: admin/ComplainType
        [HttpGet]
        public ActionResult Index(int? id)
        {
            ComplaintTypeViewModel viewmodel = new ComplaintTypeViewModel();
            if (id.HasValue && id != 0)
            {
                ComplainType model = _complaintTypeService.GetById(id.Value);
                viewmodel.ComplainName = model.ComplainName;
                viewmodel.Description = model.Description;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ComplaintTypeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ComplainType model = new ComplainType
                {
                    ComplainName = viewmodel.ComplainName,
                    Description = viewmodel.Description
                };
                _complaintTypeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ComplainType model = _complaintTypeService.GetById(viewmodel.Id);
                model.ComplainName = viewmodel.ComplainName;
                model.Description = viewmodel.Description;
                _complaintTypeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ComplainType", new { id = "" });
                }
            }
            return View();
        }

        public PartialViewResult List()
        {
            IEnumerable<ComplaintTypeViewModel> model = _complaintTypeService.GetAll().Select(p => new ComplaintTypeViewModel
            {
                ComplainName = p.ComplainName,
                Description = p.Description,
                IsActive = true,
                Id = p.Id
            });
            return PartialView(model);
        }

        [Authorize(Roles = "Superadmin, Admin, Receptionist")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ComplaintTypeViewModel model = new ComplaintTypeViewModel();
            if (id != 0)
            {
                ComplainType complaintype = _complaintTypeService.GetById(id.Value);
                model.ComplainName = complaintype.ComplainName;
                model.Description = complaintype.Description;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    ComplainType model = _complaintTypeService.GetById(id.Value);
                    _complaintTypeService.Delete(model);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}