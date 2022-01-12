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
    public class classSectionController : Controller
    {
        IClassSectionService _classSectionService;
        ISchoolClassService _schoolClassService;
        ISectionService _sectionService;

        public classSectionController(IClassSectionService classSectionService, ISchoolClassService schoolClassService, ISectionService sectionService)
        {
            _classSectionService = classSectionService;
            _schoolClassService = schoolClassService;
            _sectionService = sectionService;
        }

        // GET: admin/classSection
        public ActionResult Index()
        {
            ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "Id", "ClassName");
            ViewBag.SectionId = new SelectList(_sectionService.GetAll(), "Id", "SectionName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ClassSectionViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ClassSection model = new ClassSection
                {
                    ClassNameId = viewmodel.ClassId,
                    SectionNameId = viewmodel.SectionId
                };

                _classSectionService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "Id", "ClassName", model.ClassNameId);
                    ViewBag.SectionId = new SelectList(_sectionService.GetAll(), "Id", "SectionName", model.SectionNameId);

                    return RedirectToAction("Index");
                }
            }
            return View(viewmodel);
        }

        public ActionResult List()
        {
            IEnumerable<ClassSectionViewModel> viewmodel = _classSectionService.GetAll().Select(s => new ClassSectionViewModel
            {
                ClassId = s.ClassNameId,
                SectionId = s.SectionNameId,
                ClassName = s.ClassName.ClassName,
                SectionName = s.SectionName.SectionName,
                Id = s.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ClassSectionViewModel viewmodel = new ClassSectionViewModel();
            if (id != 0)
            {
                ClassSection model = _classSectionService.GetById(id.Value);
                viewmodel.ClassId = model.ClassNameId;
                viewmodel.ClassName = model.ClassName.ClassName;
                viewmodel.SectionId = model.SectionNameId;
                viewmodel.SectionName = model.SectionName.SectionName;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    ClassSection model = _classSectionService.GetById(id.Value);
                    _classSectionService.Delete(model);
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