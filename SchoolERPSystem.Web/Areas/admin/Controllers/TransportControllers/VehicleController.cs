using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Service.TransportService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.TransportViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.TransportControllers
{
    [Authorize(Roles = "Superadmin, Admin")]
    public class VehicleController : Controller
    {
        IVehicleService _VehicleService;

        public VehicleController(IVehicleService VehicleService)
        {
            _VehicleService = VehicleService;
        }

        // GET: admin/Vehicle
        public ActionResult Index(int? id)
        {
            VehicleViewModel viewmodel = new VehicleViewModel();
            if (id.HasValue && id != 0)
            {
                Vehicle model = _VehicleService.GetById(id.Value);
                viewmodel.DriverContact = model.DriverContact;
                viewmodel.DriverLicense = model.DriverLicense;
                viewmodel.DriverName = model.DriverName;
                viewmodel.Note = model.Note;
                viewmodel.VehicleModel = model.VehicleModel;
                viewmodel.VehicleNumber = model.VehicleNumber;
                viewmodel.YearMade = model.YearMade;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VehicleViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Vehicle model = new Vehicle
                {
                    DriverContact = viewmodel.DriverContact,
                    DriverLicense = viewmodel.DriverLicense,
                    DriverName = viewmodel.DriverName,
                    Note = viewmodel.Note,
                    VehicleModel = viewmodel.VehicleModel,
                    VehicleNumber = viewmodel.VehicleNumber,
                    YearMade = viewmodel.YearMade,
                    Id = viewmodel.Id
                };

                _VehicleService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Vehicle model = _VehicleService.GetById(viewmodel.Id);
                model.DriverContact = viewmodel.DriverContact;
                model.DriverLicense = viewmodel.DriverLicense;
                model.DriverName = viewmodel.DriverName;
                model.Note = viewmodel.Note;
                model.VehicleModel = viewmodel.VehicleModel;
                model.VehicleNumber = viewmodel.VehicleNumber;
                model.YearMade = viewmodel.YearMade;

                _VehicleService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Vehicle", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<VehicleViewModel> viewmodel = _VehicleService.GetAll().Select(x => new VehicleViewModel
            {
                DriverContact = x.DriverContact,
                DriverLicense = x.DriverLicense,
                DriverName = x.DriverName,
                Note = x.Note,
                VehicleModel = x.VehicleModel,
                VehicleNumber = x.VehicleNumber,
                YearMade = x.YearMade,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            VehicleViewModel viewmodel = new VehicleViewModel();
            if (id != 0)
            {
                Vehicle model = _VehicleService.GetById(id.Value);
                viewmodel.DriverContact = model.DriverContact;
                viewmodel.DriverLicense = model.DriverLicense;
                viewmodel.DriverName = model.DriverName;
                viewmodel.Note = model.Note;
                viewmodel.VehicleModel = model.VehicleModel;
                viewmodel.VehicleNumber = model.VehicleNumber;
                viewmodel.YearMade = model.YearMade;
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
                    Vehicle model = _VehicleService.GetById(id.Value);
                    _VehicleService.Delete(model);
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