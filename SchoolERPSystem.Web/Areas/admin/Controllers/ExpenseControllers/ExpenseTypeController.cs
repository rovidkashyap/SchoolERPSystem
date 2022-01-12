using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Service.ExpenseService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.ExpenseViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.ExpenseControllers
{
    public class ExpenseTypeController : Controller
    {
        IExpenseTypeService _ExpenseTypeService;

        public ExpenseTypeController(IExpenseTypeService ExpenseTypeService)
        {
            _ExpenseTypeService = ExpenseTypeService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            ExpenseTypeViewModel viewmodel = new ExpenseTypeViewModel();
            if (id.HasValue && id != 0)
            {
                ExpenseType model = _ExpenseTypeService.GetById(id.Value);
                viewmodel.ExpenseHead = model.ExpenseHead;
                viewmodel.Description = model.Description;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ExpenseTypeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ExpenseType model = new ExpenseType
                {
                    Description = viewmodel.Description,
                    ExpenseHead = viewmodel.ExpenseHead,
                    Id = viewmodel.Id
                };

                _ExpenseTypeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ExpenseType model = _ExpenseTypeService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.ExpenseHead = viewmodel.ExpenseHead;

                _ExpenseTypeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ExpenseType", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ExpenseTypeViewModel> viewmodel = _ExpenseTypeService.GetAll().Select(i => new ExpenseTypeViewModel
            {
                Description = i.Description,
                Id = i.Id,
                ExpenseHead = i.ExpenseHead
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ExpenseTypeViewModel viewmodel = new ExpenseTypeViewModel();
            if (id != 0)
            {
                ExpenseType model = _ExpenseTypeService.GetById(id.Value);
                viewmodel.ExpenseHead = model.ExpenseHead;
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
                    ExpenseType model = _ExpenseTypeService.GetById(id.Value);
                    _ExpenseTypeService.Delete(model);
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