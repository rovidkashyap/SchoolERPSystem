using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using SchoolERPSystem.Web.Areas.admin.Models.FrontOfficeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.admin.Controllers
{
    public class PostalReceiveController : Controller
    {
        IPostalReceiveService _postalReceiveService;

        public PostalReceiveController(IPostalReceiveService postalReceiveService)
        {
            _postalReceiveService = postalReceiveService;
        }

        // GET: admin/PostalReceive
        [HttpGet]
        public ActionResult Index(int? id)
        {
            PostalReceiveViewModel viewmodel = new PostalReceiveViewModel();
            if (id.HasValue && id != 0)
            {
                PostalReceive model = _postalReceiveService.GetById(id.Value);
                viewmodel.Address = model.Address;
                viewmodel.Date = model.Date;
                viewmodel.FromTitle = model.FromTitle;
                viewmodel.DocumentPath = model.DocumentPath;
                viewmodel.Note = model.Note;
                viewmodel.ReferenceNo = model.ReferenceNo;
                viewmodel.ToTitle = model.ToTitle;
            }

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PostalReceiveViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                PostalReceive model = new PostalReceive
                {
                    Address = viewmodel.Address,
                    Date = viewmodel.Date,
                    FromTitle = viewmodel.FromTitle,
                    DocumentPath = viewmodel.DocumentPath,
                    Note = viewmodel.Note,
                    ReferenceNo = viewmodel.ReferenceNo,
                    ToTitle = viewmodel.ToTitle,
                    Id = viewmodel.Id
                };

                _postalReceiveService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                PostalReceive model = _postalReceiveService.GetById(viewmodel.Id);
                model.Address = viewmodel.Address;
                model.Date = viewmodel.Date;
                model.FromTitle = viewmodel.FromTitle;
                model.DocumentPath = viewmodel.DocumentPath;
                model.Note = viewmodel.Note;
                model.ReferenceNo = viewmodel.ReferenceNo;
                model.ToTitle = viewmodel.ToTitle;

                _postalReceiveService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "PostalReceive", new { id = "" });
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<PostalReceiveViewModel> viewmodel = _postalReceiveService.GetAll().Select(p => new PostalReceiveViewModel
            {
                Address = p.Address,
                Date = p.Date,
                DocumentPath = p.DocumentPath,
                FromTitle = p.FromTitle,
                Note = p.Note,
                ReferenceNo = p.ReferenceNo,
                ToTitle = p.ToTitle,
                Id = p.Id
            });
            return View(viewmodel);
        }
    }
}