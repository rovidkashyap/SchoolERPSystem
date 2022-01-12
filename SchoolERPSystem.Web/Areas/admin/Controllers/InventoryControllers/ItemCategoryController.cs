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
    public class ItemCategoryController : Controller
    {
        IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            ItemCategoryViewModel viewmodel = new ItemCategoryViewModel();
            if (id.HasValue && id != 0)
            {
                ItemCategory model = _itemCategoryService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.ItemCategoryName = model.ItemCategoryName;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ItemCategoryViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ItemCategory model = new ItemCategory
                {
                    Description = viewmodel.Description,
                    ItemCategoryName = viewmodel.ItemCategoryName,
                    Id = viewmodel.Id
                };

                _itemCategoryService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ItemCategory model = _itemCategoryService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.ItemCategoryName = viewmodel.ItemCategoryName;

                _itemCategoryService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ItemCategory", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ItemCategoryViewModel> viewmodel = _itemCategoryService.GetAll().Select(i => new ItemCategoryViewModel
            {
                Description = i.Description,
                Id = i.Id,
                ItemCategoryName = i.ItemCategoryName
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ItemCategoryViewModel viewmodel = new ItemCategoryViewModel();
            if (id != 0)
            {
                ItemCategory model = _itemCategoryService.GetById(id.Value);
                viewmodel.ItemCategoryName = model.ItemCategoryName;
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
                    ItemCategory model = _itemCategoryService.GetById(id.Value);
                    _itemCategoryService.Delete(model);
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