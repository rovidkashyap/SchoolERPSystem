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
    public class VisitorPurposeController : Controller
    {
        IPurposeService _purposeService;

        public VisitorPurposeController(IPurposeService purposeService)
        {
            _purposeService = purposeService;
        }

        // GET: admin/VisitorPurpose
        [HttpGet]
        public ActionResult Index(int? id)
        {
            PurposeViewModel viewmodel = new PurposeViewModel();
            if (id.HasValue && id != 0)
            {
                Purpose model = _purposeService.GetById(id.Value);
                viewmodel.PurposeName = model.PurposeName;
                viewmodel.Description = model.Description;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PurposeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Purpose model = new Purpose
                {
                    PurposeName = viewmodel.PurposeName,
                    Description = viewmodel.Description
                };
                _purposeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Purpose model = _purposeService.GetById(viewmodel.Id);
                model.PurposeName = viewmodel.PurposeName;
                model.Description = viewmodel.Description;
                _purposeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "VisitorPurpose", new { id = "" });
                }
            }
            return View();
        }

        public PartialViewResult List()
        {
            IEnumerable<PurposeViewModel> model = _purposeService.GetAll().Select(p => new PurposeViewModel
            {
                PurposeName = p.PurposeName,
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
            PurposeViewModel model = new PurposeViewModel();
            if (id != 0)
            {
                Purpose purpose = _purposeService.GetById(id.Value);
                model.PurposeName = purpose.PurposeName;
                model.Description = purpose.Description;
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
                    Purpose model = _purposeService.GetById(id.Value);
                    _purposeService.Delete(model);
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