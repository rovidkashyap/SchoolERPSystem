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
    public class ItemStockController : Controller
    {
        IItemStockService _itemStockService;
        IItemService _itemService;
        IItemCategoryService _itemCategoryService;
        IItemSupplierService _itemSupplierService;
        IItemStoreService _itemStoreService;

        public ItemStockController(IItemStockService itemStockService, IItemService itemService, IItemCategoryService itemCategoryService, IItemSupplierService itemSupplierService, IItemStoreService itemStoreService)
        {
            _itemStockService = itemStockService;
            _itemService = itemService;
            _itemCategoryService = itemCategoryService;
            _itemSupplierService = itemSupplierService;
            _itemStoreService = itemStoreService;
        }

        // GET: admin/ItemStock
        public ActionResult Index(int? id)
        {
            ItemStockViewModel viewmodel = new ItemStockViewModel();
            if (id.HasValue && id != 0)
            {
                ItemStock model = _itemStockService.GetById(id.Value);
                viewmodel.Date = model.Date;
                viewmodel.Description = model.Description;
                viewmodel.Document = model.Document;
                viewmodel.Quantity = model.Quantity;
                viewmodel.ItemCategoryId = model.ItemCategoryId;
                viewmodel.ItemCategory = model.ItemCategory.ItemCategoryName;
                viewmodel.ItemId = model.ItemId;
                viewmodel.ItemName = model.Item.ItemName;
                viewmodel.ItemStoreId = model.ItemStoreId;
                viewmodel.ItemStore = model.ItemStore.ItemStoreName;
                viewmodel.ItemSupplierId = model.ItemSupplierId;
                viewmodel.ItemSupplier = model.ItemSupplier.Name;
            }

            ViewBag.CategoryId = new SelectList(_itemCategoryService.GetAll(), "Id", "ItemCategoryName");
            ViewBag.StoreId = new SelectList(_itemStoreService.GetAll(), "Id", "ItemStoreName");
            ViewBag.ItemId = new SelectList(_itemService.GetAll(), "Id", "ItemName");
            ViewBag.SupplierId = new SelectList(_itemSupplierService.GetAll(), "Id", "Name");

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ItemStockViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ItemStock model = new ItemStock
                {
                    Date = viewmodel.Date,
                    Description = viewmodel.Description,
                    Document = viewmodel.Document,
                    Id = viewmodel.Id,
                    ItemCategoryId = viewmodel.ItemCategoryId,
                    ItemId = viewmodel.ItemId,
                    ItemStoreId = viewmodel.ItemStoreId,
                    ItemSupplierId = viewmodel.ItemSupplierId,
                    Quantity = viewmodel.Quantity
                };

                _itemStockService.Create(model);
                if (model.Id > 0)
                {
                    ViewBag.CategoryId = new SelectList(_itemCategoryService.GetAll(), "Id", "ItemCategoryName", model.ItemCategoryId);
                    ViewBag.StoreId = new SelectList(_itemStoreService.GetAll(), "Id", "ItemStoreName", model.ItemStoreId);
                    ViewBag.ItemId = new SelectList(_itemService.GetAll(), "Id", "ItemName", model.ItemId);
                    ViewBag.SupplieryId = new SelectList(_itemSupplierService.GetAll(), "Id", "ItemSupplierName", model.ItemSupplierId);

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ItemStock model = _itemStockService.GetById(viewmodel.Id);
                model.Date = viewmodel.Date;
                model.Description = viewmodel.Description;
                model.Document = viewmodel.Document;
                model.ItemCategoryId = viewmodel.ItemCategoryId;
                model.ItemId = viewmodel.ItemId;
                model.ItemStoreId = viewmodel.ItemStoreId;
                model.ItemSupplierId = viewmodel.ItemSupplierId;
                model.Quantity = viewmodel.Quantity;

                _itemStockService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ItemStock", new { id = "" });
                }
            }

            return View();
        }

        public ActionResult List()
        {
            IEnumerable<ItemStockViewModel> viewmodel = _itemStockService.GetAll().Select(s => new ItemStockViewModel
            {
                Date = s.Date,
                Description = s.Description,
                Document = s.Document,
                Id = s.Id,
                ItemCategoryId = s.ItemCategoryId,
                ItemCategory = s.ItemCategory.ItemCategoryName,
                ItemId = s.ItemId,
                ItemName = s.Item.ItemName,
                ItemStoreId = s.ItemStoreId,
                ItemStore = s.ItemStore.ItemStoreName,
                ItemSupplierId = s.ItemSupplierId,
                ItemSupplier = s.ItemSupplier.Name,
                Quantity = s.Quantity
            });

            return View(viewmodel);
        }
    }
}