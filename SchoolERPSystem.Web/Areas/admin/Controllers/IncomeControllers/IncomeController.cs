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
    [Authorize(Roles = "Superadmin, Admin")]
    public class IncomeController : Controller
    {
        IIncomeService _IncomeService;
        IIncomeTypeService _IncomeTypeService;

        public IncomeController(IIncomeService IncomeService, IIncomeTypeService IncomeTypeService)
        {
            _IncomeService = IncomeService;
            _IncomeTypeService = IncomeTypeService;
        }

        // GET: admin/Income
        public ActionResult Index(int? id)
        {
            IncomeViewModel viewmodel = new IncomeViewModel();
            if (id.HasValue && id != 0)
            {
                Income model = _IncomeService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.Amount = model.Amount;
                viewmodel.Date = model.Date;
                viewmodel.Document = model.Document;
                viewmodel.IncomeTypeId = model.IncomeTypeId;
                viewmodel.IncomeTypeName = model.IncomeTypeName.IncomeHead;
                viewmodel.InvoiceNumber = model.InvoiceNumber;
                viewmodel.Name = model.Name;
            }

            ViewBag.IncomeTypeId = new SelectList(_IncomeTypeService.GetAll(), "Id", "IncomeHead");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IncomeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Income model = new Income
                {
                    Description = viewmodel.Description,
                    IncomeTypeId = viewmodel.IncomeTypeId,
                    Amount = viewmodel.Amount,
                    Date = Convert.ToDateTime(viewmodel.Date),
                    Document = viewmodel.Document,
                    InvoiceNumber = viewmodel.InvoiceNumber,
                    Name = viewmodel.Name,
                    Id = viewmodel.Id
                };

                _IncomeService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.IncomeTypeId = new SelectList(_IncomeTypeService.GetAll(), "Id", "IncomeHead", model.IncomeTypeId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                Income model = _IncomeService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.IncomeTypeId = viewmodel.IncomeTypeId;
                model.Amount = viewmodel.Amount;
                model.Date = Convert.ToDateTime(viewmodel.Date);
                model.Document = viewmodel.Document;
                model.InvoiceNumber = viewmodel.InvoiceNumber;
                model.Name = viewmodel.Name;

                _IncomeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Income", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<IncomeViewModel> viewmodel = _IncomeService.GetAll().Select(i => new IncomeViewModel
            {
                Description = i.Description,
                Id = i.Id,
                IncomeTypeId = i.IncomeTypeId,
                IncomeTypeName = i.IncomeTypeName.IncomeHead,
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
            IncomeViewModel viewmodel = new IncomeViewModel();
            if (id != 0)
            {
                Income model = _IncomeService.GetById(id.Value);
                viewmodel.IncomeTypeId = model.IncomeTypeId;
                viewmodel.Amount = model.Amount;
                viewmodel.Date = model.Date;
                viewmodel.Document = model.Document;
                viewmodel.Description = model.Description;
                viewmodel.IncomeTypeName = model.IncomeTypeName.IncomeHead;
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
                    Income model = _IncomeService.GetById(id.Value);
                    _IncomeService.Delete(model);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult search()
        {
            return View();
        }
    }
}