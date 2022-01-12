using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Service.HostelService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.HostelViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.HostelRoomControllers
{
    [Authorize(Roles = "Superadmin ,Admin")]
    public class HostelRoomController : Controller
    {
        IHostelRoomService _HostelRoomService;
        IHostelService _hostelService;
        IRoomTypeService _roomTypeService;

        public HostelRoomController(IHostelRoomService HostelRoomService, IHostelService hostelService, IRoomTypeService roomTypeService)
        {
            _HostelRoomService = HostelRoomService;
            _hostelService = hostelService;
            _roomTypeService = roomTypeService;
        }

        // GET: admin/HostelRoom
        public ActionResult Index(int? id)
        {
            HostelRoomViewModel viewmodel = new HostelRoomViewModel();
            if (id.HasValue && id != 0)
            {
                HostelRoom model = _HostelRoomService.GetById(id.Value);
                viewmodel.CostPerBed = model.CostPerBed;
                viewmodel.Description = model.Description;
                viewmodel.HostelId = model.HostelId;
                viewmodel.Hostel = model.Hostel.HostelName;
                viewmodel.NoOfBed = model.NoOfBed;
                viewmodel.RoomNumberOrName = model.RoomNumberOrName;
                viewmodel.RoomTypeId = model.RoomTypeId;
                viewmodel.RoomType = model.RoomType.RoomTypeName;
            }

            ViewBag.RoomTypeId = new SelectList(_roomTypeService.GetAll(), "Id", "RoomTypeName");
            ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HostelRoomViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                HostelRoom model = new HostelRoom
                {
                    CostPerBed = viewmodel.CostPerBed,
                    Description = viewmodel.Description,
                    HostelId = viewmodel.HostelId,
                    NoOfBed = viewmodel.NoOfBed,
                    RoomNumberOrName = viewmodel.RoomNumberOrName,
                    RoomTypeId = viewmodel.RoomTypeId,
                    Id = viewmodel.Id
                };

                _HostelRoomService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                HostelRoom model = _HostelRoomService.GetById(viewmodel.Id);
                model.CostPerBed = viewmodel.CostPerBed;
                model.Description = viewmodel.Description;
                model.HostelId = viewmodel.HostelId;
                model.NoOfBed = viewmodel.NoOfBed;
                model.RoomNumberOrName = viewmodel.RoomNumberOrName;
                model.RoomTypeId = viewmodel.RoomTypeId;

                _HostelRoomService.Update(model);
                if (model.Id > 0)
                {
                    ViewBag.RoomTypeId = new SelectList(_roomTypeService.GetAll(), "Id", "RoomTypeName", model.RoomTypeId);
                    ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName", model.HostelId);

                    return RedirectToAction("Index", "HostelRoom", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<HostelRoomViewModel> viewmodel = _HostelRoomService.GetAll().Select(x => new HostelRoomViewModel
            {
                CostPerBed = x.CostPerBed,
                Description = x.Description,
                HostelId = x.HostelId,
                Hostel = x.Hostel.HostelName,
                NoOfBed = x.NoOfBed,
                RoomNumberOrName = x.RoomNumberOrName,
                RoomTypeId = x.RoomTypeId,
                RoomType = x.RoomType.RoomTypeName,
                Id = x.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            HostelRoomViewModel viewmodel = new HostelRoomViewModel();
            if (id != 0)
            {
                HostelRoom model = _HostelRoomService.GetById(id.Value);
                viewmodel.CostPerBed = model.CostPerBed;
                viewmodel.Description = model.Description;
                viewmodel.HostelId = model.HostelId;
                viewmodel.Hostel = model.Hostel.HostelName;
                viewmodel.NoOfBed = model.NoOfBed;
                viewmodel.RoomNumberOrName = model.RoomNumberOrName;
                viewmodel.RoomTypeId = model.RoomTypeId;
                viewmodel.RoomType = model.RoomType.RoomTypeName;
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
                    HostelRoom model = _HostelRoomService.GetById(id.Value);
                    _HostelRoomService.Delete(model);
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