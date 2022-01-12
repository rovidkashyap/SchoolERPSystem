using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using SchoolERPSystem.Web.Models.DependencyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Controllers
{
    [Authorize(Roles = "Superadmin, Admin")]
    public class DesignationsController : Controller
    {
        IDesignationService _DesignationService;

        public DesignationsController(IDesignationService DesignationService)
        {
            _DesignationService = DesignationService;
        }

        [ChildActionOnly]
        // GET: Designation
        public PartialViewResult Index()
        {
            IEnumerable<DesignationViewModel> model = _DesignationService.GetAll().Select(g => new DesignationViewModel
            {
                Name = g.Name,
                Id = g.Id
            });
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult Create(int? id)
        {
            DesignationViewModel viewmodel = new DesignationViewModel();
            if (id.HasValue && id != 0)
            {
                Designation model = _DesignationService.GetById(id.Value);
                viewmodel.Name = model.Name;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesignationViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Designation model = new Designation
                {
                    Name = viewmodel.Name
                };
                _DesignationService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                Designation model = _DesignationService.GetById(viewmodel.Id);
                model.Name = viewmodel.Name;
                _DesignationService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create", "Designation", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            DesignationViewModel model = new DesignationViewModel();
            if (id != 0)
            {
                Designation designation = _DesignationService.GetById(id.Value);
                model.Name = designation.Name;
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
                    Designation model = _DesignationService.GetById(id.Value);
                    _DesignationService.Delete(model);
                    return RedirectToAction("create");
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