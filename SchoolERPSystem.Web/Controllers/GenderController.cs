using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using SchoolERPSystem.Web.Models.DependencyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Controllers
{
    [Authorize]
    public class GenderController : Controller
    {
        IGenderService _GenderService;

        public GenderController(IGenderService genderService)
        {
            _GenderService = genderService;
        }

        [ChildActionOnly]
        // GET: Gender
        public PartialViewResult Index()
        {
            IEnumerable<GenderViewModel> model = _GenderService.GetAll().Select(g => new GenderViewModel
            {
                Name = g.GenderName,
                Id = g.Id
            });
            return PartialView(model);
        }

        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public ActionResult Create(int? id)
        {
            GenderViewModel viewmodel = new GenderViewModel();
            if (id.HasValue && id != 0)
            {
                Gender model = _GenderService.GetById(id.Value);
                viewmodel.Name = model.GenderName;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenderViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Gender model = new Gender
                {
                    GenderName = viewmodel.Name
                };
                _GenderService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                Gender model = _GenderService.GetById(viewmodel.Id);
                model.GenderName = viewmodel.Name;
                _GenderService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create", "Gender", new { id = "" });
                }
            }
            return View();
        }

        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            GenderViewModel model = new GenderViewModel();
            if (id!= 0)
            {
                Gender gender = _GenderService.GetById(id.Value);
                model.Name = gender.GenderName;
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
                    Gender model = _GenderService.GetById(id.Value);
                    _GenderService.Delete(model);
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