using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Models.Setting;
using SchoolERPSystem.Service.DependenciesService.Interfaces.GeneralSettingInterfaces;
using SchoolERPSystem.Web.Models.GeneralSettingViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Controllers.GeneralSettingControllers
{
    public class GeneralSettingController : Controller
    {
        IGeneralSettingService _generalSettingService;
        ICurrencyService _currencyService;
        ITimezoneService _timezoneService;
        ISessionService _sessionService;
        ILanguageService _languageService;

        public GeneralSettingController(IGeneralSettingService generalSettingService, ICurrencyService currencyService, ITimezoneService timezoneService, ISessionService sessionService, ILanguageService languageService)
        {
            _generalSettingService = generalSettingService;
            _currencyService = currencyService;
            _timezoneService = timezoneService;
            _sessionService = sessionService;
            _languageService = languageService;
        }

        // GET: GeneralSetting
        public ActionResult Index()
        {
            IEnumerable<GeneralSettingViewModel> viewmodel = _generalSettingService.GetAll().Select(g => new GeneralSettingViewModel
            {
                CurrencyId = g.CurrencyId,
                CurrencyName = g.CurrencyName.CurrencyName,
                SessionId = g.SessionId,
                SessionName = g.SessionName.SessionName,
                TimezoneId = g.TimezoneId,
                TimezoneName = g.TimezoneName.TimezoneName,
                LanguageId = g.LanguageId,
                LanguageName = g.LanguageName.LanguageName,
                CurrencySymbol = g.CurrencySymbol,
                FeesDueDays = g.FeesDueDays,
                PhoneNumber1 = g.PhoneNumber1,
                PhoneNumber2 = g.PhoneNumber2,
                SchoolAddress = g.SchoolAddress,
                SchoolCode = g.SchoolCode,
                SchoolEmail = g.SchoolEmail,
                SchoolName = g.SchoolName,
                SessionStartMonth = g.SessionStartMonth,
                Id = g.Id
            });

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GeneralSetting setting = _generalSettingService.GetById(id.Value);

            GeneralSettingViewModel viewmodel = new GeneralSettingViewModel
            {
                CurrencyId = setting.CurrencyId,
                CurrencyName = setting.CurrencyName.CurrencyName,
                LanguageId = setting.LanguageId,
                LanguageName = setting.LanguageName.LanguageName,
                SessionId = setting.SessionId,
                SessionName = setting.SessionName.SessionName,
                TimezoneId = setting.TimezoneId,
                TimezoneName = setting.TimezoneName.TimezoneName,
                CurrencySymbol = setting.CurrencySymbol,
                FeesDueDays = setting.FeesDueDays,
                PhoneNumber1 = setting.PhoneNumber1,
                PhoneNumber2 = setting.PhoneNumber2,
                SchoolAddress = setting.SchoolAddress,
                SchoolCode = setting.SchoolCode,
                SchoolEmail = setting.SchoolEmail,
                SchoolName = setting.SchoolName,
                SessionStartMonth = setting.SessionStartMonth
            };

            if (viewmodel == null)
            {
                return HttpNotFound();
            }

            ViewBag.CurrencyId = new SelectList(_currencyService.GetAll(), "Id", "CurrencyName", viewmodel.CurrencyId);
            ViewBag.LanguageId = new SelectList(_languageService.GetAll(), "Id", "LanguageName", viewmodel.LanguageId);
            ViewBag.SessionId = new SelectList(_sessionService.GetAll(), "Id", "SessionName", viewmodel.SessionId);
            ViewBag.TimezoneId = new SelectList(_timezoneService.GetAll(), "Id", "TimezoneName", viewmodel.TimezoneId);

            return PartialView(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeneralSettingViewModel viewmodel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                GeneralSetting setting = _generalSettingService.GetById(viewmodel.Id);

                setting.CurrencyId = viewmodel.CurrencyId;
                setting.CurrencySymbol = viewmodel.CurrencySymbol;
                setting.FeesDueDays = viewmodel.FeesDueDays;
                setting.LanguageId = viewmodel.LanguageId;
                setting.PhoneNumber1 = viewmodel.PhoneNumber1;
                setting.PhoneNumber2 = viewmodel.PhoneNumber2;
                setting.SchoolAddress = viewmodel.SchoolAddress;
                setting.SchoolCode = viewmodel.SchoolCode;
                setting.SchoolEmail = viewmodel.SchoolEmail;
                setting.SchoolName = viewmodel.SchoolName;
                setting.SessionId = viewmodel.SessionId;
                setting.SessionStartMonth = viewmodel.SessionStartMonth;
                setting.TimezoneId = viewmodel.TimezoneId;

                _generalSettingService.Update(setting);

                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(_currencyService.GetAll(), "Id", "CurrencyName", viewmodel.CurrencyId);
            ViewBag.LanguageId = new SelectList(_languageService.GetAll(), "Id", "LanguageName", viewmodel.LanguageId);
            ViewBag.SessionId = new SelectList(_sessionService.GetAll(), "Id", "SessionName", viewmodel.SessionId);
            ViewBag.TimezoneId = new SelectList(_timezoneService.GetAll(), "Id", "TimezoneName", viewmodel.TimezoneId);

            return RedirectToAction("Index");
        }
    }
}