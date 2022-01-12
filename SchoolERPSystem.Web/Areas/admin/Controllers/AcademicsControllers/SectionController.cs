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
    public class SectionController : Controller
    {
        ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: admin/Section
        public ActionResult Index(int? id)
        {
            SectionViewModel viewmodel = new SectionViewModel();
            if (id.HasValue && id != 0)
            {
                Section model = _sectionService.GetById(id.Value);
                viewmodel.SectionName = model.SectionName;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SectionViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Section model = new Section
                {
                    SectionName = viewmodel.SectionName
                };
                _sectionService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Section model = _sectionService.GetById(viewmodel.Id);
                model.SectionName = viewmodel.SectionName;

                _sectionService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Section", new { id = "" });
                }
            }
            return View();
        }

        public PartialViewResult List()
        {
            IEnumerable<SectionViewModel> model = _sectionService.GetAll().Select(s => new SectionViewModel
            {
                SectionName = s.SectionName,
                Id = s.Id
            });

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            SectionViewModel model = new SectionViewModel();
            if (id != 0)
            {
                Section section = _sectionService.GetById(id.Value);
                model.SectionName = section.SectionName;
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
                    Section model = _sectionService.GetById(id.Value);
                    _sectionService.Delete(model);
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