using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers
{
    [Authorize(Roles = "Superadmin, Admin, Receptionist")]
    public class ReferenceController : Controller
    {
        IReferencesService _referenceService;

        public ReferenceController(IReferencesService ReferenceService)
        {
            _referenceService = ReferenceService;
        }

        // GET: admin/Reference
        [HttpGet]
        public ActionResult Index(int? id)
        {
            ReferenceViewModel viewmodel = new ReferenceViewModel();
            if (id.HasValue && id != 0)
            {
                Reference model = _referenceService.GetById(id.Value);
                viewmodel.ReferenceName = model.ReferenceName;
                viewmodel.Description = model.Description;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ReferenceViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Reference model = new Reference
                {
                    ReferenceName = viewmodel.ReferenceName,
                    Description = viewmodel.Description
                };
                _referenceService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Reference model = _referenceService.GetById(viewmodel.Id);
                model.ReferenceName = viewmodel.ReferenceName;
                model.Description = viewmodel.Description;
                _referenceService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Reference", new { id = "" });
                }
            }
            return View();
        }

        public PartialViewResult List()
        {
            IEnumerable<ReferenceViewModel> model = _referenceService.GetAll().Select(p => new ReferenceViewModel
            {
                ReferenceName = p.ReferenceName,
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
            ReferenceViewModel model = new ReferenceViewModel();
            if (id != 0)
            {
                Reference Reference = _referenceService.GetById(id.Value);
                model.ReferenceName = Reference.ReferenceName;
                model.Description = Reference.Description;
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
                    Reference model = _referenceService.GetById(id.Value);
                    _referenceService.Delete(model);
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