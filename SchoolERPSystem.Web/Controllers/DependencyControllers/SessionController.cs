using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Service.DependenciesService.Interfaces.GeneralSettingInterfaces;
using SchoolERPSystem.Web.Models.DependencyViewModels.SettingViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Controllers.DependencyControllers
{
    public class SessionController : Controller
    {
        ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [ChildActionOnly]
        // GET: Session
        public PartialViewResult List()
        {
            IEnumerable<SessionViewModel> model = _sessionService.GetAll().Select(g => new SessionViewModel
            {
                SessionName = g.SessionName,
                isActive = g.isActive,
                Id = g.Id
            });
            return PartialView(model);
        }

        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public ActionResult Index(int? id)
        {
            SessionViewModel viewmodel = new SessionViewModel();
            if (id.HasValue && id != 0)
            {
                Session model = _sessionService.GetById(id.Value);
                viewmodel.SessionName = model.SessionName;
                viewmodel.isActive = model.isActive;
            }
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SessionViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Session model = new Session
                {
                    SessionName = viewmodel.SessionName,
                    isActive = viewmodel.isActive
                };
                _sessionService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Session model = _sessionService.GetById(viewmodel.Id);
                model.SessionName = viewmodel.SessionName;
                model.isActive = viewmodel.isActive;
                _sessionService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Session", new { id = "" });
                }
            }
            return View();
        }

        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            SessionViewModel model = new SessionViewModel();
            if (id != 0)
            {
                Session Session = _sessionService.GetById(id.Value);
                model.SessionName = Session.SessionName;
                model.isActive = Session.isActive;
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
                    Session model = _sessionService.GetById(id.Value);
                    _sessionService.Delete(model);
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