using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Service.AcademicsService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.AcademicsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.AcademicsControllers
{
    public class classController : Controller
    {
        ISectionService _sectionService;
        ISchoolClassService _schoolClassService;

        public classController(ISectionService sectionService, ISchoolClassService schoolClassService)
        {
            _sectionService = sectionService;
            _schoolClassService = schoolClassService;
        }

        // GET: admin/class
        public ActionResult Index(int? id)
        {
            SchoolClassViewModel viewmodel = new SchoolClassViewModel();
            if (id.HasValue && id != 0)
            {
                SchoolClass model = _schoolClassService.GetById(id.Value);
                viewmodel.ClassName = model.ClassName;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SchoolClassViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                SchoolClass model = new SchoolClass
                {
                    ClassName = viewmodel.ClassName,
                    Id = viewmodel.Id
                };

                _schoolClassService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                SchoolClass model = _schoolClassService.GetById(viewmodel.Id);
                model.ClassName = viewmodel.ClassName;

                _schoolClassService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "class", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<SchoolClassViewModel> viewmodel = _schoolClassService.GetAll().Select(s => new SchoolClassViewModel
            {
                ClassName = s.ClassName,
                Id = s.Id
            });

            return View(viewmodel);
        }
    }
}