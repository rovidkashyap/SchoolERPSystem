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
    public class RouteController : Controller
    {
        IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        // GET: admin/Route
        public ActionResult Index(int? id)
        {
            RouteViewModel viewmodel = new RouteViewModel();
            if (id.HasValue && id != 0)
            {
                Route model = _routeService.GetById(id.Value);
                viewmodel.RouteTitle = model.RouteTitle;
                viewmodel.Fare = model.Fare;
                viewmodel.Description = model.Description;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RouteViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Route model = new Route
                {
                    RouteTitle = viewmodel.RouteTitle,
                    Fare = viewmodel.Fare,
                    Description = viewmodel.Description,
                    Id = viewmodel.Id
                };

                _routeService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Route model = _routeService.GetById(viewmodel.Id);
                model.RouteTitle = viewmodel.RouteTitle;
                model.Fare = viewmodel.Fare;
                model.Description = viewmodel.Description;

                _routeService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Route", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<RouteViewModel> viewmodel = _routeService.GetAll().Select(x => new RouteViewModel
            {
                RouteTitle = x.RouteTitle,
                Description = x.Description,
                Fare = x.Fare,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            RouteViewModel viewmodel = new RouteViewModel();
            if (id != 0)
            {
                Route model = _routeService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.Fare = model.Fare;
                viewmodel.RouteTitle = model.RouteTitle;
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
                    Route model = _routeService.GetById(id.Value);
                    _routeService.Delete(model);
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