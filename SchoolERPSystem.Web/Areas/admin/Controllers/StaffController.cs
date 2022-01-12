using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolERPSystem.Models;
using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Service;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using SchoolERPSystem.Service.StaffModelService.Interfaces;
using SchoolERPSystem.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        ApplicationDbContext context;

        IGenderService _GenderService;
        IDepartmentService _DepartmentService;
        IDesignationService _DesignationService;
        IMaritalStatusService _MaritalStatusService;
        IContractTypeService _ContractTypeService;

        IStaffProfileService _StaffProfileService;
        IStaffPayrollService _StaffPayrollService;
        IStaffLeavesService _StaffLeavesService;
        IStaffBankDetailsService _StaffBankDetailsService;

        public StaffController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public StaffController(IStaffProfileService staffProfileService, IGenderService genderService, IContractTypeService contractTypeService, 
            IMaritalStatusService maritalStatusService, IDesignationService designationService, IDepartmentService departmentService, 
            IStaffPayrollService staffPayrollService, IStaffLeavesService staffLeavesService, IStaffBankDetailsService staffBankDetailsService)
        {
            context = new ApplicationDbContext();

            _GenderService = genderService;
            _MaritalStatusService = maritalStatusService;
            _DepartmentService = departmentService;
            _DesignationService = designationService;
            _ContractTypeService = contractTypeService;

            _StaffProfileService = staffProfileService;
            _StaffPayrollService = staffPayrollService;
            _StaffLeavesService = staffLeavesService;
            _StaffBankDetailsService = staffBankDetailsService;
        }


        // GET: Admin/Staff
        public ActionResult Index()
        {
            IEnumerable<StaffProfileViewModel> staffProfile = _StaffProfileService.GetAll().Select(s => new StaffProfileViewModel
            {
                ApplicationUserId = s.ApplicationUserId,
                UserRoles = s.RoleName,
                StaffId = s.StaffId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderId = s.GenderId,
                GenderName = s.GenderName.GenderName,
                DepartmentId = s.DepartmentId,
                DepartmentName = s.DepartmentName.Name,
                DesignationId = s.DesignationId,
                DesignationName = s.DesignationName.Name,
                UserName = s.ApplicationUser.UserName,
                Email = s.ApplicationUser.Email,
                Mobile = s.Mobile,
                MaritalStatusId = s.MaritalStatusId,
                MaritalStatusName = s.MaritalStatusName.MaritalStatusName,
            });


            //staffProfile = _StaffPayrollService.GetAll().Select(sp => new StaffProfileViewModel
            //{
            //    ApplicationUserId = sp.ApplicationUserId,
            //    ContractTypeId = sp.ContractTypeId,
            //    ContractTypeName = sp.ContractTypeName.Name,
            //    BasicSalary = sp.BasicSalary,
            //    Location = sp.Location,
            //    WorkShift = sp.WorkShift,
            //    StaffEPFNo = sp.StaffEPFNo
            //});

            //staffProfile = _StaffLeavesService.GetAll().Select(sl => new StaffProfileViewModel
            //{
            //    ApplicationUserId = sl.ApplicationUserId,
            //    MedicalLeaves = sl.MedicalLeaves,
            //    MaternityLeaves = sl.MaternityLeaves,
            //    CasualLeaves = sl.CasualLeaves
            //});

            //staffProfile = _StaffBankDetailsService.GetAll().Select(sb => new StaffProfileViewModel
            //{
            //    ApplicationUserId = sb.ApplicationUserId,
            //    AccountTitle = sb.AccountTitle,
            //    BankAccountNumber = sb.BankAccountNumber,
            //    BankName = sb.BankName,
            //    IFSCCode = sb.IFSCCode,
            //    BankBranchName = sb.BankBranchName
            //});

            return View(staffProfile);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName");
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName");
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name");
            ViewBag.ContractTypeId = new SelectList(_ContractTypeService.GetAll(), "Id", "Name");

            return View(new StaffProfileViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StaffProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    await this.UserManager.AddToRoleAsync(user.Id, model.UserRoles);

                    StaffProfile staffmodel = new StaffProfile
                    {
                        ApplicationUserId = user.Id,
                        StaffId = model.StaffId,
                        DepartmentId = model.DepartmentId,
                        RoleName = model.UserRoles,
                        DesignationId = model.DesignationId,
                        GenderId = model.GenderId,
                        MaritalStatusId = model.MaritalStatusId,
                        Mobile = model.Mobile,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        DateOfJoining = model.DateOfJoining,
                        CurrentAddress = model.CurrentAddress,
                        PermanentAddress = model.PermanentAddress,
                        Qualification = model.Qualification,
                        WorkExperience = model.WorkExperience,
                        EmergencyContact = model.EmergencyContact,
                        FatherName = model.FatherName,
                        MotherName = model.MotherName,
                        Note = model.Note,
                        FacebookURL = model.FacebookURL,
                        TwitterURL = model.TwitterURL,
                        LinkedInURL = model.LinkedInURL,
                        InstagramURL = model.InstagramURL
                    };

                    StaffPayroll staffPayroll = new StaffPayroll
                    {
                        ApplicationUserId = user.Id,
                        BasicSalary = model.BasicSalary,
                        ContractTypeId = model.ContractTypeId,
                        Location = model.Location,
                        StaffEPFNo = model.StaffEPFNo,
                        WorkShift = model.WorkShift
                    };

                    StaffLeaves staffLeaves = new StaffLeaves
                    {
                        ApplicationUserId = user.Id,
                        CasualLeaves = model.CasualLeaves,
                        MaternityLeaves = model.MaternityLeaves,
                        MedicalLeaves = model.MedicalLeaves
                    };

                    StaffBankDetails staffBank = new StaffBankDetails
                    {
                        ApplicationUserId = user.Id,
                        AccountTitle = model.AccountTitle,
                        BankAccountNumber = model.BankAccountNumber,
                        BankBranchName = model.BankBranchName,
                        BankName = model.BankName,
                        IFSCCode = model.IFSCCode
                    };

                    _StaffProfileService.Create(staffmodel);
                    _StaffPayrollService.Create(staffPayroll);
                    _StaffLeavesService.Create(staffLeaves);
                    _StaffBankDetailsService.Create(staffBank);

                    //Ends Here
                    return RedirectToAction("Index", "Staff", new { area = "Admin" });
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
                ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
                ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
                ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
                ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);
                ViewBag.ContractTypeId = new SelectList(_ContractTypeService.GetAll(), "Id", "Name", model.ContractTypeId);
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [Authorize(Roles = "Superadmin, Admin")]
        [HttpGet]
        public ActionResult profile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StaffProfile staffProfile = _StaffProfileService.GetById(id);
            StaffPayroll staffPayroll = _StaffPayrollService.GetById(id);
            StaffLeaves staffLeaves = _StaffLeavesService.GetById(id);
            StaffBankDetails staffBankDetails = _StaffBankDetailsService.GetById(id);

            StaffProfileViewModel model = new StaffProfileViewModel
            {
                #region Staff Profile
                ApplicationUserId = staffProfile.ApplicationUserId,
                StaffId = staffProfile.StaffId,
                UserRoles = staffProfile.RoleName,
                FirstName = staffProfile.FirstName,
                LastName = staffProfile.LastName,
                FatherName = staffProfile.FatherName,
                MotherName = staffProfile.MotherName,
                DateOfBirth = staffProfile.DateOfBirth,
                DateOfJoining = staffProfile.DateOfJoining,
                EmergencyContact = staffProfile.EmergencyContact,
                CurrentAddress = staffProfile.CurrentAddress,
                PermanentAddress = staffProfile.PermanentAddress,
                Qualification = staffProfile.Qualification,
                Note = staffProfile.Note,
                GenderId = staffProfile.GenderId,
                GenderName = staffProfile.GenderName.GenderName,
                DepartmentId = staffProfile.DepartmentId,
                DepartmentName = staffProfile.DepartmentName.Name,
                DesignationId = staffProfile.DesignationId,
                DesignationName = staffProfile.DesignationName.Name,
                UserName = staffProfile.ApplicationUser.UserName,
                Email = staffProfile.ApplicationUser.Email,
                Mobile = staffProfile.Mobile,
                MaritalStatusId = staffProfile.MaritalStatusId,
                MaritalStatusName = staffProfile.MaritalStatusName.MaritalStatusName,
                WorkExperience = staffProfile.WorkExperience,
                FacebookURL = staffProfile.FacebookURL,
                TwitterURL = staffProfile.TwitterURL,
                LinkedInURL = staffProfile.LinkedInURL,
                InstagramURL = staffProfile.InstagramURL,
                #endregion

                #region Staff Payroll
                StaffEPFNo = staffPayroll.StaffEPFNo,
                BasicSalary = staffPayroll.BasicSalary,
                ContractTypeId = staffPayroll.ContractTypeId,
                ContractTypeName = staffPayroll.ContractTypeName.Name,
                WorkShift = staffPayroll.WorkShift,
                Location = staffPayroll.Location,
                #endregion

                #region Staff Leaves
                MedicalLeaves = staffLeaves.MedicalLeaves,
                CasualLeaves = staffLeaves.CasualLeaves,
                MaternityLeaves = staffLeaves.MaternityLeaves,
                #endregion

                #region Staff Bank Details
                BankAccountNumber = staffBankDetails.BankAccountNumber,
                AccountTitle = staffBankDetails.AccountTitle,
                BankName = staffBankDetails.BankName,
                IFSCCode = staffBankDetails.IFSCCode,
                BankBranchName = staffBankDetails.BankBranchName
                #endregion

            };

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StaffProfile staffProfile = _StaffProfileService.GetById(id);
            StaffLeaves staffLeaves = _StaffLeavesService.GetById(id);
            StaffPayroll staffPayroll = _StaffPayrollService.GetById(id);
            StaffBankDetails staffBankDetails = _StaffBankDetailsService.GetById(id);

            StaffProfileViewModel model = new StaffProfileViewModel
            {
                UserRoles = staffProfile.RoleName,
                FirstName = staffProfile.FirstName,
                LastName = staffProfile.LastName,
                GenderId = staffProfile.GenderId,
                GenderName = staffProfile.GenderName.GenderName,
                DepartmentId = staffProfile.DepartmentId,
                DepartmentName = staffProfile.DepartmentName.Name,
                DesignationId = staffProfile.DesignationId,
                DesignationName = staffProfile.DesignationName.Name,
                UserName = staffProfile.ApplicationUser.UserName,
                Email = staffProfile.ApplicationUser.Email,
                Mobile = staffProfile.Mobile,
                CurrentAddress = staffProfile.CurrentAddress,
                DateOfBirth = staffProfile.DateOfBirth,
                DateOfJoining = staffProfile.DateOfJoining,
                EmergencyContact = staffProfile.EmergencyContact,
                FacebookURL = staffProfile.FacebookURL,
                InstagramURL = staffProfile.InstagramURL,
                LinkedInURL = staffProfile.LinkedInURL,
                FatherName = staffProfile.FatherName,
                MotherName = staffProfile.MotherName,
                Note = staffProfile.Note,
                PermanentAddress = staffProfile.PermanentAddress,
                Qualification = staffProfile.Qualification,
                TwitterURL = staffProfile.TwitterURL,
                WorkExperience = staffProfile.WorkExperience,
                StaffId = staffProfile.StaffId,
                MaritalStatusId = staffProfile.MaritalStatusId,
                MaritalStatusName = staffProfile.MaritalStatusName.MaritalStatusName,
                ApplicationUserId = staffProfile.ApplicationUserId,
                

                //Staff Leaves Viewmodel
                MedicalLeaves = staffLeaves.MedicalLeaves,
                MaternityLeaves = staffLeaves.MaternityLeaves,
                CasualLeaves = staffLeaves.CasualLeaves,

                //Staff Payroll Viewmodel
                ContractTypeId = staffPayroll.ContractTypeId,
                ContractTypeName = staffPayroll.ContractTypeName.Name,
                StaffEPFNo = staffPayroll.StaffEPFNo,
                WorkShift = staffPayroll.WorkShift,
                Location = staffPayroll.Location,
                BasicSalary = staffPayroll.BasicSalary,

                //Staff Bank Details Viewmodel
                AccountTitle = staffBankDetails.AccountTitle,
                BankAccountNumber = staffBankDetails.BankAccountNumber,
                BankBranchName = staffBankDetails.BankBranchName,
                BankName = staffBankDetails.BankName,
                IFSCCode = staffBankDetails.IFSCCode
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name", model.UserRoles);
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);
            ViewBag.ContractTypeId = new SelectList(_ContractTypeService.GetAll(), "Id", "Name", model.ContractTypeId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffProfileViewModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                StaffProfile s = _StaffProfileService.GetById(model.ApplicationUserId);
                StaffPayroll sp = _StaffPayrollService.GetById(model.ApplicationUserId);
                StaffLeaves sl = _StaffLeavesService.GetById(model.ApplicationUserId);
                StaffBankDetails sb = _StaffBankDetailsService.GetById(model.ApplicationUserId);

                #region StaffProfile
                s.RoleName = model.UserRoles;
                s.FirstName = model.FirstName;
                s.LastName = model.LastName;
                s.GenderId = model.GenderId;
                s.DepartmentId = model.DepartmentId;
                s.DesignationId = model.DesignationId;
                s.MaritalStatusId = model.MaritalStatusId;
                s.ApplicationUser.UserName = model.UserName;
                s.ApplicationUser.Email = model.Email;
                s.Mobile = model.Mobile;
                s.DateOfBirth = model.DateOfBirth;
                s.EmergencyContact = model.EmergencyContact;
                s.CurrentAddress = model.CurrentAddress;
                s.DateOfJoining = model.DateOfJoining;
                s.FatherName = model.FatherName;
                s.MotherName = model.MotherName;
                s.Note = model.Note;
                s.PermanentAddress = model.PermanentAddress;
                s.Qualification = model.Qualification;
                s.StaffId = model.StaffId;
                s.TwitterURL = model.TwitterURL;
                s.FacebookURL = model.FacebookURL;
                s.LinkedInURL = model.LinkedInURL;
                s.InstagramURL = model.InstagramURL;
                s.WorkExperience = model.WorkExperience;
                #endregion

                #region StaffPayroll
                sp.ApplicationUserId = model.ApplicationUserId;
                sp.BasicSalary = model.BasicSalary;
                sp.ContractTypeId = model.ContractTypeId;
                sp.Location = model.Location;
                sp.StaffEPFNo = model.StaffEPFNo;
                sp.WorkShift = model.WorkShift;
                #endregion

                #region StaffLeaves
                sl.ApplicationUserId = model.ApplicationUserId;
                sl.CasualLeaves = model.CasualLeaves;
                sl.MaternityLeaves = model.MaternityLeaves;
                sl.MedicalLeaves = model.MedicalLeaves;
                #endregion

                #region StaffBankDetails
                sb.ApplicationUserId = model.ApplicationUserId;
                sb.AccountTitle = model.AccountTitle;
                sb.BankAccountNumber = model.BankAccountNumber;
                sb.BankBranchName = model.BankBranchName;
                sb.BankName = model.BankName;
                sb.IFSCCode = model.IFSCCode;
                #endregion

                _StaffProfileService.Update(s);
                _StaffPayrollService.Update(sp);
                _StaffLeavesService.Update(sl);
                _StaffBankDetailsService.Update(sb);

                if (s.ApplicationUserId != null)
                {
                    RedirectToAction("Index");
                }
            }

            //ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Superadmin")).ToList(), "Name", "Name");
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
            ViewBag.GenderId = new SelectList(_GenderService.GetAll(), "Id", "GenderName", model.GenderId);
            ViewBag.MaritalStatusId = new SelectList(_MaritalStatusService.GetAll(), "Id", "MaritalStatusName", model.MaritalStatusId);
            ViewBag.DepartmentId = new SelectList(_DepartmentService.GetAll(), "Id", "Name", model.DepartmentId);
            ViewBag.DesignationId = new SelectList(_DesignationService.GetAll(), "Id", "Name", model.DesignationId);
            ViewBag.ContractTypeId = new SelectList(_ContractTypeService.GetAll(), "Id", "Name", model.ContractTypeId);

            return RedirectToAction("profile", "Staff", new { id = model.ApplicationUserId, @area = "Admin" });
        }
    }
}