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
    public class ContractTypeController : Controller
    {
        IContractTypeService _ContractTypeService;

        public ContractTypeController(IContractTypeService contractTypeService)
        {
            _ContractTypeService = contractTypeService;
        }

        [ChildActionOnly]
        // GET: ContractType
        public PartialViewResult Index()
        {
            IEnumerable<ContractTypeViewModel> model = _ContractTypeService.GetAll().Select(c => new ContractTypeViewModel
            {
                Name = c.Name,
                Description = c.Description,
                Id = c.Id
            });
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            ContractTypeViewModel viewmodel = new ContractTypeViewModel();
            if (id.HasValue && id != 0)
            {
                ContractType model = _ContractTypeService.GetById(id.Value);
                viewmodel.Name = model.Name;
                viewmodel.Description = model.Description;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractTypeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ContractType model = new ContractType
                {
                    Name = viewmodel.Name,
                    Description = viewmodel.Description
                };
                _ContractTypeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create");
                }
            }
            else
            {
                ContractType model = _ContractTypeService.GetById(viewmodel.Id);
                model.Name = viewmodel.Name;
                model.Description = viewmodel.Description;
                _ContractTypeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Create", "ContractType", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ContractTypeViewModel model = new ContractTypeViewModel();
            if (id != 0)
            {
                ContractType contractType = _ContractTypeService.GetById(id.Value);
                model.Name = contractType.Name;
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
                    ContractType model = _ContractTypeService.GetById(id.Value);
                    _ContractTypeService.Delete(model);
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