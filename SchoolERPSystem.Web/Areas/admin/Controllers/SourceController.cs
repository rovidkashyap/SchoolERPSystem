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
    public class SourceController : Controller
    {
        ISourceService _sourceService;

        public SourceController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        // GET: admin/source
        [HttpGet]
        public ActionResult Index(int? id)
        {
            SourceViewModel viewmodel = new SourceViewModel();
            if (id.HasValue && id != 0)
            {
                Source model = _sourceService.GetById(id.Value);
                viewmodel.SourceName = model.SourceName;
                viewmodel.SourceDescription = model.SourceDescription;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SourceViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Source model = new Source
                {
                    SourceName = viewmodel.SourceName,
                    SourceDescription = viewmodel.SourceDescription
                };
                _sourceService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Source model = _sourceService.GetById(viewmodel.Id);
                model.SourceName = viewmodel.SourceName;
                model.SourceDescription = viewmodel.SourceDescription;
                _sourceService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Source", new { id = "" });
                }
            }
            return View();
        }

        public PartialViewResult List()
        {
            IEnumerable<SourceViewModel> model = _sourceService.GetAll().Select(p => new SourceViewModel
            {
                SourceName = p.SourceName,
                SourceDescription = p.SourceDescription,
                IsActive = true,
                Id = p.Id
            });
            return PartialView(model);
        }

        [Authorize(Roles = "Superadmin, Admin, Receptionist")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            SourceViewModel model = new SourceViewModel();
            if (id != 0)
            {
                Source source = _sourceService.GetById(id.Value);
                model.SourceName = source.SourceName;
                model.SourceDescription = source.SourceDescription;
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
                    Source model = _sourceService.GetById(id.Value);
                    _sourceService.Delete(model);
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