using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Service.HostelService.Interfaces;
using SchoolERPSystem.Service.TransportService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.HostelControllers
{
    [Authorize(Roles = "Superadmin, Admin")]
    public class HostelController : Controller
    {

        IHostelService _HostelService;
        IHostelTypeService _hostelTypeService;

        public HostelController(IHostelService HostelService, IHostelTypeService hostelTypeService)
        {
            _HostelService = HostelService;
            _hostelTypeService = hostelTypeService;
        }

        // GET: admin/Hostel
        public ActionResult Index(int? id)
        {
            HostelViewModel viewmodel = new HostelViewModel();
            if (id.HasValue && id != 0)
            {
                Hostel model = _HostelService.GetById(id.Value);
                viewmodel.Address = model.Address;
                viewmodel.Description = model.Description;
                viewmodel.HostelName = model.HostelName;
                viewmodel.HostelTypeId = model.HostelTypeId;
                viewmodel.HostelType = model.HostelType.HostelTypeName;
                viewmodel.Intake = model.Intake;
            }

            ViewBag.HostelTypeId = new SelectList(_hostelTypeService.GetAll(), "Id", "HostelTypeName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HostelViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Hostel model = new Hostel
                {
                    Address = viewmodel.Address,
                    Description = viewmodel.Description,
                    HostelName = viewmodel.HostelName,
                    HostelTypeId = viewmodel.HostelTypeId,
                    Intake = viewmodel.Intake,
                    Id = viewmodel.Id
                };

                _HostelService.Create(model);
                if (model.Id > 0)
                {

                    return RedirectToAction("Index");
                }
            }
            else
            {
                Hostel model = _HostelService.GetById(viewmodel.Id);
                model.Address = viewmodel.Address;
                model.Description = viewmodel.Description;
                model.HostelName = viewmodel.HostelName;
                model.HostelTypeId = viewmodel.HostelTypeId;
                model.Intake = viewmodel.Intake;

                _HostelService.Update(model);
                if (model.Id > 0)
                {
                    ViewBag.HostelTypeId = new SelectList(_hostelTypeService.GetAll(), "Id", "HostelTypeName", model.HostelTypeId);

                    return RedirectToAction("Index", "Hostel", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<HostelViewModel> viewmodel = _HostelService.GetAll().Select(x => new HostelViewModel
            {
                Address = x.Address,
                Description = x.Description,
                HostelName = x.HostelName,
                HostelTypeId = x.HostelTypeId,
                HostelType = x.HostelType.HostelTypeName,
                Intake = x.Intake,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            HostelViewModel viewmodel = new HostelViewModel();
            if (id != 0)
            {
                Hostel model = _HostelService.GetById(id.Value);
                viewmodel.Address = model.Address;
                viewmodel.Description = model.Description;
                viewmodel.HostelName = model.HostelName;
                viewmodel.HostelTypeId = model.HostelTypeId;
                viewmodel.HostelType = model.HostelType.HostelTypeName;
                viewmodel.Intake = model.Intake;
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
                    Hostel model = _HostelService.GetById(id.Value);
                    _HostelService.Delete(model);
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