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
    public class PostalDispatchController : Controller
    {
        IPostalDispatchService _PostalDispatchService;

        public PostalDispatchController(IPostalDispatchService PostalDispatchService)
        {
            _PostalDispatchService = PostalDispatchService;
        }

        // GET: admin/PostalDispatch
        [HttpGet]
        public ActionResult Index(int? id)
        {
            PostalDispatchViewModel viewmodel = new PostalDispatchViewModel();
            if (id.HasValue && id != 0)
            {
                PostalDispatch model = _PostalDispatchService.GetById(id.Value);
                viewmodel.Address = model.Address;
                viewmodel.Date = DateTime.Now;
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
        public ActionResult Index(PostalDispatchViewModel viewmodel)
        {
            if (viewmodel.Id == 0)
            {
                PostalDispatch model = new PostalDispatch
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
                _PostalDispatchService.Create(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                PostalDispatch model = _PostalDispatchService.GetById(viewmodel.Id);
                model.Address = viewmodel.Address;
                model.Date = viewmodel.Date;
                model.FromTitle = viewmodel.FromTitle;
                model.DocumentPath = viewmodel.DocumentPath;
                model.Note = viewmodel.Note;
                model.ReferenceNo = viewmodel.ReferenceNo;
                model.ToTitle = viewmodel.ToTitle;

                _PostalDispatchService.Update(model);
                if (model.Id > 0)
                {
                    return RedirectToAction("Index", "PostalDispatch", new { id = "" });
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<PostalDispatchViewModel> viewmodel = _PostalDispatchService.GetAll().Select(p => new PostalDispatchViewModel
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