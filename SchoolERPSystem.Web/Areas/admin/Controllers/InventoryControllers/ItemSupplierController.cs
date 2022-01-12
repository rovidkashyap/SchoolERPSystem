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
    public class ItemSupplierController : Controller
    {
        IItemSupplierService _itemSupplierService;

        public ItemSupplierController(IItemSupplierService itemSupplierService)
        {
            _itemSupplierService = itemSupplierService;
        }

        // GET: admin/Item
        public ActionResult Index(int? id)
        {
            ItemSupplierViewModel viewmodel = new ItemSupplierViewModel();
            if (id.HasValue && id != 0)
            {
                ItemSupplier model = _itemSupplierService.GetById(id.Value);
                viewmodel.Description = model.Description;
                viewmodel.Address = model.Address;
                viewmodel.ContactPersonEmail = model.ContactPersonEmail;
                viewmodel.ContactPersonName = model.ContactPersonName;
                viewmodel.ContactPersonPhone = model.ContactPersonPhone;
                viewmodel.Email = model.Email;
                viewmodel.Name = model.Name;
                viewmodel.Phone = model.Phone;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ItemSupplierViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                ItemSupplier model = new ItemSupplier
                {
                    Description = viewmodel.Description,
                    Address = viewmodel.Address,
                    ContactPersonEmail = viewmodel.ContactPersonEmail,
                    ContactPersonName = viewmodel.ContactPersonName,
                    ContactPersonPhone = viewmodel.ContactPersonPhone,
                    Email = viewmodel.Email,
                    Name = viewmodel.Name,
                    Phone = viewmodel.Phone,
                    Id = viewmodel.Id
                };

                _itemSupplierService.Create(model);
                if (model.Id > 0)
                {
                    
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ItemSupplier model = _itemSupplierService.GetById(viewmodel.Id);
                model.Description = viewmodel.Description;
                model.Address = viewmodel.Address;
                model.ContactPersonEmail = viewmodel.ContactPersonEmail;
                model.ContactPersonName = viewmodel.ContactPersonName;
                model.ContactPersonPhone = viewmodel.ContactPersonPhone;
                model.Email = viewmodel.Email;
                model.Name = viewmodel.Name;
                model.Phone = viewmodel.Phone;

                _itemSupplierService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "ItemSupplier", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<ItemSupplierViewModel> viewmodel = _itemSupplierService.GetAll().Select(i => new ItemSupplierViewModel
            {
                Description = i.Description,
                Id = i.Id,
                Address = i.Address,
                ContactPersonEmail = i.ContactPersonEmail,
                ContactPersonName = i.ContactPersonName,
                ContactPersonPhone = i.ContactPersonPhone,
                Email = i.Email,
                Name = i.Name,
                Phone = i.Phone
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ItemSupplierViewModel viewmodel = new ItemSupplierViewModel();
            if (id != 0)
            {
                ItemSupplier model = _itemSupplierService.GetById(id.Value);
                viewmodel.Phone = model.Phone;
                viewmodel.Name = model.Name;
                viewmodel.ContactPersonPhone = model.ContactPersonPhone;
                viewmodel.ContactPersonName = model.ContactPersonName;
                viewmodel.ContactPersonEmail = model.ContactPersonEmail;
                viewmodel.Address = model.Address;
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
                    ItemSupplier model = _itemSupplierService.GetById(id.Value);
                    _itemSupplierService.Delete(model);
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