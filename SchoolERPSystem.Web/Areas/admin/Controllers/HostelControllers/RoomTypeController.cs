using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Service.HostelService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.RoomTypeControllers
{
    public class RoomTypeController : Controller
    {
        IRoomTypeService _RoomTypeService;

        public RoomTypeController(IRoomTypeService RoomTypeService)
        {
            _RoomTypeService = RoomTypeService;
        }

        // GET: admin/RoomType
        public ActionResult Index(int? id)
        {
            RoomTypeViewModel viewmodel = new RoomTypeViewModel();
            if (id.HasValue && id != 0)
            {
                RoomType model = _RoomTypeService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.RoomTypeName = model.RoomTypeName;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RoomTypeViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                RoomType model = new RoomType
                {
                    Description = viewmodel.Description,
                    RoomTypeName = viewmodel.RoomTypeName,
                    Id = viewmodel.Id
                };

                _RoomTypeService.Create(model);
                if (model.Id > 0)
                {

                    return RedirectToAction("Index");
                }
            }
            else
            {
                RoomType model = _RoomTypeService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.RoomTypeName = viewmodel.RoomTypeName;

                _RoomTypeService.Update(model);
                if (model.Id > 0)
                {

                    return RedirectToAction("Index", "RoomType", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<RoomTypeViewModel> viewmodel = _RoomTypeService.GetAll().Select(x => new RoomTypeViewModel
            {
                Description = x.Description,
                RoomTypeName = x.RoomTypeName,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            RoomTypeViewModel viewmodel = new RoomTypeViewModel();
            if (id != 0)
            {
                RoomType model = _RoomTypeService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.RoomTypeName = model.RoomTypeName;
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
                    RoomType model = _RoomTypeService.GetById(id.Value);
                    _RoomTypeService.Delete(model);
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