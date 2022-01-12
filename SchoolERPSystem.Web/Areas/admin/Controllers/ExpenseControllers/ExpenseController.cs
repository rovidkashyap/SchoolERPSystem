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
    public class ExpenseController : Controller
    {
        IExpenseService _ExpenseService;
        IExpenseTypeService _ExpenseTypeService;

        public ExpenseController(IExpenseService ExpenseService, IExpenseTypeService ExpenseTypeService)
        {
            _ExpenseService = ExpenseService;
            _ExpenseTypeService = ExpenseTypeService;
        }

        // GET: admin/Expense
        public ActionResult Index(int? id)
        {
            ExpenseViewModel viewmodel = new ExpenseViewModel();
            if (id.HasValue && id != 0)
            {
                Expense model = _ExpenseService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.Amount = model.Amount;
                viewmodel.Date = model.Date;
                viewmodel.Document = model.Document;
                viewmodel.ExpenseTypeId = model.ExpenseTypeId;
                viewmodel.ExpenseTypeName = model.ExpenseTypeName.ExpenseHead;
                viewmodel.InvoiceNumber = model.InvoiceNumber;
                viewmodel.Name = model.Name;
            }

            ViewBag.ExpenseTypeId = new SelectList(_ExpenseTypeService.GetAll(), "Id", "ExpenseHead");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ExpenseViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Expense model = new Expense
                {
                    Description = viewmodel.Description,
                    ExpenseTypeId = viewmodel.ExpenseTypeId,
                    Amount = viewmodel.Amount,
                    Date = Convert.ToDateTime(viewmodel.Date),
                    Document = viewmodel.Document,
                    InvoiceNumber = viewmodel.InvoiceNumber,
                    Name = viewmodel.Name,
                    Id = viewmodel.Id
                };

                _ExpenseService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.ExpenseTypeId = new SelectList(_ExpenseTypeService.GetAll(), "Id", "ExpenseHead", model.ExpenseTypeId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                Expense model = _ExpenseService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.ExpenseTypeId = viewmodel.ExpenseTypeId;
                model.Amount = viewmodel.Amount;
                model.Date = Convert.ToDateTime(viewmodel.Date);
                model.Document = viewmodel.Document;
                model.InvoiceNumber = viewmodel.InvoiceNumber;
                model.Name = viewmodel.Name;

                _ExpenseService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Expense", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ExpenseViewModel> viewmodel = _ExpenseService.GetAll().Select(i => new ExpenseViewModel
            {
                Description = i.Description,
                Id = i.Id,
                ExpenseTypeId = i.ExpenseTypeId,
                ExpenseTypeName = i.ExpenseTypeName.ExpenseHead,
                Amount = i.Amount,
                Date = i.Date,
                Document = i.Document,
                InvoiceNumber = i.InvoiceNumber,
                Name = i.Name
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ExpenseViewModel viewmodel = new ExpenseViewModel();
            if (id != 0)
            {
                Expense model = _ExpenseService.GetById(id.Value);
                viewmodel.ExpenseTypeId = model.ExpenseTypeId;
                viewmodel.Amount = model.Amount;
                viewmodel.Date = model.Date;
                viewmodel.Document = model.Document;
                viewmodel.Description = model.Description;
                viewmodel.ExpenseTypeName = model.ExpenseTypeName.ExpenseHead;
                viewmodel.InvoiceNumber = model.InvoiceNumber;
                viewmodel.Name = model.Name;
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
                    Expense model = _ExpenseService.GetById(id.Value);
                    _ExpenseService.Delete(model);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}