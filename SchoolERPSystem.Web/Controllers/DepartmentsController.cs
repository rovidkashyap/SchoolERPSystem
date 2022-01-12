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
    public class DepartmentsController : Controller
    {
        IDepartmentService _DepartmentService;

        public DepartmentsController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        [ChildActionOnly]
        // GET: Department
        public PartialViewResult Index()
        {
            IEnumerable<DepartmentViewModel> model = _DepartmentService.GetAll().Select(g => new DepartmentViewModel
            {
                Name = g.Name,
                Id = g.Id
            });
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult Create(int? id)
        {
            DepartmentViewModel viewmodel = new DepartmentViewModel();
            if (id.HasValue && id != 0)
            {
                Department model = _DepartmentService.GetById(id.Value);
                viewmodel.Name = model.Name;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Department model = new Department
                {
                    Name = viewmodel.Name
                };
                _DepartmentService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                Department model = _DepartmentService.GetById(viewmodel.Id);
                model.Name = viewmodel.Name;
                _DepartmentService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create", "Departments", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            DepartmentViewModel model = new DepartmentViewModel();
            if (id != 0)
            {
                Department department = _DepartmentService.GetById(id.Value);
                model.Name = department.Name;
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
                    Department model = _DepartmentService.GetById(id.Value);
                    _DepartmentService.Delete(model);
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