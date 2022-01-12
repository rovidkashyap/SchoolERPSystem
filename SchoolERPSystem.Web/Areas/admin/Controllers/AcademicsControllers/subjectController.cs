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
    public class subjectController : Controller
    {
        ISubjectService _subjectService;

        public subjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: admin/subject
        public ActionResult Index(int? id)
        {
            SubjectViewModel viewmodel = new SubjectViewModel();
            if (id.HasValue && id != 0)
            {
                Subject model = _subjectService.GetById(id.Value);
                viewmodel.SubjectCode = model.SubjectCode;
                viewmodel.SubjectName = model.SubjectName;
                viewmodel.SubjectType = model.SubjectType;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SubjectViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Subject model = new Subject
                {
                    SubjectCode = viewmodel.SubjectCode,
                    SubjectName = viewmodel.SubjectName,
                    SubjectType = viewmodel.SubjectType
                };

                _subjectService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Subject model = _subjectService.GetById(viewmodel.Id);
                model.SubjectCode = viewmodel.SubjectCode;
                model.SubjectName = viewmodel.SubjectName;
                model.SubjectType = viewmodel.SubjectType;

                _subjectService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Subject", new { id = "" });
                }
            }

            return View();
        }

        public ActionResult List()
        {
            IEnumerable<SubjectViewModel> viewmodel = _subjectService.GetAll().Select(s => new SubjectViewModel
            {
                SubjectCode = s.SubjectCode,
                SubjectName = s.SubjectName,
                SubjectType = s.SubjectType,
                Id = s.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            SubjectViewModel viewmodel = new SubjectViewModel();
            if (id != 0)
            {
                Subject model = _subjectService.GetById(id.Value);
                viewmodel.SubjectCode = model.SubjectCode;
                viewmodel.SubjectName = model.SubjectName;
                viewmodel.SubjectType = model.SubjectType;
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
                    Subject model = _subjectService.GetById(id.Value);
                    _subjectService.Delete(model);
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