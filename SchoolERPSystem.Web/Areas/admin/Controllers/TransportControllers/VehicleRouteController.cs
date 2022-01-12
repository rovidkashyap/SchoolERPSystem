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
    public class VehicleRouteController : Controller
    {
        IVehicleRouteService _VehicleRouteService;
        IVehicleService _vehicleService;
        IRouteService _routeService;

        public VehicleRouteController(IVehicleRouteService VehicleRouteService, IRouteService routeService, IVehicleService vehicleService)
        {
            _VehicleRouteService = VehicleRouteService;
            _routeService = routeService;
            _vehicleService = vehicleService;
        }

        // GET: admin/VehicleRoute
        public ActionResult Index(int? id)
        {
            VehicleRouteViewModel viewmodel = new VehicleRouteViewModel();
            if (id.HasValue && id != 0)
            {
                VehicleRoute model = _VehicleRouteService.GetById(id.Value);
                viewmodel.RouteId = model.RouteId;
                viewmodel.Route = model.Route.RouteTitle;
                viewmodel.VehicleId = model.VehicleId;
                viewmodel.Vehicle = model.Vehicle.VehicleNumber;
            }

            ViewBag.RouteId = new SelectList(_routeService.GetAll(), "Id", "RouteTitle");
            ViewBag.VehicleId = new SelectList(_vehicleService.GetAll(), "Id", "VehicleNumber");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VehicleRouteViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                VehicleRoute model = new VehicleRoute
                {
                    RouteId = viewmodel.RouteId,
                    VehicleId = viewmodel.VehicleId,
                    Id = viewmodel.Id
                };

                _VehicleRouteService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.RouteId = new SelectList(_routeService.GetAll(), "Id", "RouteTitle", model.RouteId);
                    ViewBag.VehicleId = new SelectList(_vehicleService.GetAll(), "Id", "VehicleNumber", model.VehicleId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                VehicleRoute model = _VehicleRouteService.GetById(viewmodel.Id);
                model.RouteId = viewmodel.RouteId;
                model.VehicleId = viewmodel.VehicleId;

                _VehicleRouteService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "VehicleRoute", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<VehicleRouteViewModel> viewmodel = _VehicleRouteService.GetAll().Select(x => new VehicleRouteViewModel
            {
                RouteId = x.RouteId,
                Route = x.Route.RouteTitle,
                VehicleId = x.VehicleId,
                Vehicle = x.Vehicle.VehicleNumber,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            VehicleRouteViewModel viewmodel = new VehicleRouteViewModel();
            if (id != 0)
            {
                VehicleRoute model = _VehicleRouteService.GetById(id.Value);
                viewmodel.RouteId = model.RouteId;
                viewmodel.Route = model.Route.RouteTitle;
                viewmodel.VehicleId = model.VehicleId;
                viewmodel.Vehicle = model.Vehicle.VehicleNumber;
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
                    VehicleRoute model = _VehicleRouteService.GetById(id.Value);
                    _VehicleRouteService.Delete(model);
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