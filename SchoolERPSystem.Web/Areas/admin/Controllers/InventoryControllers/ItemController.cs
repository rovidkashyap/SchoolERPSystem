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
    public class ItemController : Controller
    {
        IItemService _itemService;
        IItemCategoryService _itemCategoryService;

        public ItemController(IItemService itemService, IItemCategoryService itemCategoryService)
        {
            _itemService = itemService;
            _itemCategoryService = itemCategoryService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            ItemViewModel viewmodel = new ItemViewModel();
            if (id.HasValue && id != 0)
            {
                Item model = _itemService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.ItemName = model.ItemName;
                viewmodel.ItemCategoryId = model.ItemCategoryId;
                viewmodel.ItemCategory = model.ItemCategory.ItemCategoryName;
            }

            ViewBag.ItemCategoryId = new SelectList(_itemCategoryService.GetAll(), "Id", "ItemCategoryName");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ItemViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                Item model = new Item
                {
                    Description = viewmodel.Description,
                    ItemCategoryId = viewmodel.ItemCategoryId,
                    ItemName = viewmodel.ItemName,
                    Id = viewmodel.Id
                };

                _itemService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.ItemCategoryId = new SelectList(_itemCategoryService.GetAll(), "Id", "ItemCategoryName", model.ItemCategoryId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                Item model = _itemService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.ItemCategoryId = viewmodel.ItemCategoryId;
                model.ItemName = viewmodel.ItemName;

                _itemService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "Item", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ItemViewModel> viewmodel = _itemService.GetAll().Select(i => new ItemViewModel
            {
                Description = i.Description,
                Id = i.Id,
                ItemCategoryId = i.ItemCategoryId,
                ItemCategory = i.ItemCategory.ItemCategoryName,
                ItemName = i.ItemName
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ItemViewModel viewmodel = new ItemViewModel();
            if (id != 0)
            {
                Item model = _itemService.GetById(id.Value);
                viewmodel.ItemName = model.ItemName;
                viewmodel.ItemCategoryId = model.ItemCategoryId;
                viewmodel.ItemCategory = model.ItemCategory.ItemCategoryName;
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
                    Item model = _itemService.GetById(id.Value);
                    _itemService.Delete(model);
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