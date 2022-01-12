using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Service.Inventory.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.InventoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers.InventoryControllers
{
    public class ItemStoreController : Controller
    {
        IItemStoreService _itemStoreService;

        public ItemStoreController(IItemStoreService itemStoreService)
        {
            _itemStoreService = itemStoreService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            ItemStoreViewModel viewmodel = new ItemStoreViewModel();
            if (id.HasValue && id != 0)
            {
                ItemStore model = _itemStoreService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.ItemStockCode = model.ItemStockCode;
                viewmodel.ItemStoreName = model.ItemStoreName;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ItemStoreViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ItemStore model = new ItemStore
                {
                    Description = viewmodel.Description,
                    ItemStockCode = viewmodel.ItemStockCode,
                    ItemStoreName = viewmodel.ItemStoreName,
                    Id = viewmodel.Id
                };

                _itemStoreService.Create(model);
                if (model.Id > 0)
                {

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ItemStore model = _itemStoreService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.ItemStockCode = viewmodel.ItemStockCode;
                model.ItemStoreName = viewmodel.ItemStoreName;

                _itemStoreService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ItemStore", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ItemStoreViewModel> viewmodel = _itemStoreService.GetAll().Select(i => new ItemStoreViewModel
            {
                Description = i.Description,
                Id = i.Id,
                ItemStockCode = i.ItemStockCode,
                ItemStoreName = i.ItemStoreName
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ItemStoreViewModel viewmodel = new ItemStoreViewModel();
            if (id != 0)
            {
                ItemStore model = _itemStoreService.GetById(id.Value);
                viewmodel.ItemStockCode = model.ItemStockCode;
                viewmodel.ItemStoreName = model.ItemStoreName;
                viewmodel.Description = model.Description;
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
                    ItemStore model = _itemStoreService.GetById(id.Value);
                    _itemStoreService.Delete(model);
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