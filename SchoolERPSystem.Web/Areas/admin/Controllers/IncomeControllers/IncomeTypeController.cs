using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Service.IncomeService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.IncomeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.IncomeControllers
{
    public class IncomeTypeController : Controller
    {
        IIncomeTypeService _IncomeTypeService;

        public IncomeTypeController(IIncomeTypeService IncomeTypeService)
        {
            _IncomeTypeService = IncomeTypeService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            IncomeTypeViewModel viewmodel = new IncomeTypeViewModel();
            if (id.HasValue && id != 0)
            {
                IncomeType model = _IncomeTypeService.GetById(id.Value);
                viewmodel.IncomeHead = model.IncomeHead;
                viewmodel.Description = model.Description;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IncomeTypeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                IncomeType model = new IncomeType
                {
                    Description = viewmodel.Description,
                    IncomeHead = viewmodel.IncomeHead,
                    Id = viewmodel.Id
                };

                _IncomeTypeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                IncomeType model = _IncomeTypeService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.IncomeHead = viewmodel.IncomeHead;

                _IncomeTypeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "IncomeType", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<IncomeTypeViewModel> viewmodel = _IncomeTypeService.GetAll().Select(i => new IncomeTypeViewModel
            {
                Description = i.Description,
                Id = i.Id,
                IncomeHead = i.IncomeHead
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            IncomeTypeViewModel viewmodel = new IncomeTypeViewModel();
            if (id != 0)
            {
                IncomeType model = _IncomeTypeService.GetById(id.Value);
                viewmodel.IncomeHead = model.IncomeHead;
                viewmodel.Description = model.Description;
            }
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    IncomeType model = _IncomeTypeService.GetById(id.Value);
                    _IncomeTypeService.Delete(model);
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