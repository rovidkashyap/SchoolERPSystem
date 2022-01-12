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
    public class MaritalStatusController : Controller
    {
        IMaritalStatusService _MaritalStatusService;

        public MaritalStatusController(IMaritalStatusService MaritalStatusService)
        {
            _MaritalStatusService = MaritalStatusService;
        }

        [ChildActionOnly]
        // GET: MaritalStatus
        public PartialViewResult Index()
        {
            IEnumerable<MaritalStatusViewModel> model = _MaritalStatusService.GetAll().Select(g => new MaritalStatusViewModel
            {
                Name = g.MaritalStatusName,
                Id = g.Id
            });
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult Create(int? id)
        {
            MaritalStatusViewModel viewmodel = new MaritalStatusViewModel();
            if (id.HasValue && id != 0)
            {
                MaritalStatus model = _MaritalStatusService.GetById(id.Value);
                viewmodel.Name = model.MaritalStatusName;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaritalStatusViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                MaritalStatus model = new MaritalStatus
                {
                    MaritalStatusName = viewmodel.Name
                };
                _MaritalStatusService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                MaritalStatus model = _MaritalStatusService.GetById(viewmodel.Id);
                model.MaritalStatusName = viewmodel.Name;
                _MaritalStatusService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create", "MaritalStatus", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            MaritalStatusViewModel model = new MaritalStatusViewModel();
            if (id != 0)
            {
                MaritalStatus maritalStatus = _MaritalStatusService.GetById(id.Value);
                model.Name = maritalStatus.MaritalStatusName;
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
                    MaritalStatus model = _MaritalStatusService.GetById(id.Value);
                    _MaritalStatusService.Delete(model);
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