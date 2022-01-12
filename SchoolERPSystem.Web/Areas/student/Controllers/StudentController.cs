using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Service.AcademicsService.Interfaces;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using SchoolERPSystem.Service.DependenciesService.Interfaces.StudentInterfaces;
using SchoolERPSystem.Service.HostelService.Interfaces;
using SchoolERPSystem.Service.StudentModelService.Interfaces;
using SchoolERPSystem.Service.TransportService.Interfaces;
using SchoolERPSystem.Web.Areas.student.Helpers;
using SchoolERPSystem.Web.Areas.student.Models.StudentAdmissionViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolERPSystem.Web.Areas.student.Controllers
{
    [Authorize(Roles = "Superadmin, Admin")]
    public class StudentController : Controller
    {
        ISchoolClassService _schoolClassService;
        ISectionService _SectionService;
        IGenderService _genderService;
        ICategoryService _categoryService;
        IBloodGroupService _bloodGroupService;
        IStudentHouseService _studentHouseService;
        IHostelService _hostelService;
        IHostelRoomService _hostelRoomService;
        IVehicleRouteService _vehicleRouteService;

        IStudentAdmissionService _studentAdmissionService;
        IStudentBankingService _studentBankingService;
        IStudentDocumentService _studentDocumentService;
        IStudentHostelService _studentHostelService;
        IStudentTransportService _studentTransportService;
        IStudentAuthenticationService _studentAuthenticationService;


        public StudentController(IStudentAdmissionService studentAdmissionService, IStudentBankingService studentBankingService, IStudentDocumentService studentDocumentService,
            IStudentHostelService studentHostelService, IStudentTransportService studentTransportService,
            ISchoolClassService schoolClassService, ISectionService SectionService, IGenderService genderService, ICategoryService categoryService,
            IBloodGroupService bloodGroupService, IStudentHouseService studentHouseService, IHostelService hostelService, IHostelRoomService hostelRoomService,
            IVehicleRouteService vehicleRouteService, IStudentAuthenticationService studentAuthenticationService)
        {
            _schoolClassService = schoolClassService;
            _SectionService = SectionService;
            _genderService = genderService;
            _categoryService = categoryService;
            _bloodGroupService = bloodGroupService;
            _studentHouseService = studentHouseService;
            _hostelService = hostelService;
            _hostelRoomService = hostelRoomService;
            _vehicleRouteService = vehicleRouteService;

            _studentAdmissionService = studentAdmissionService;
            _studentBankingService = studentBankingService;
            _studentDocumentService = studentDocumentService;
            _studentHostelService = studentHostelService;
            _studentTransportService = studentTransportService;
            _studentAuthenticationService = studentAuthenticationService;
        }

        // GET: student/Student
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentAdmission studentAdmission = _studentAdmissionService.GetById(id.Value);
            StudentBanking studentBanking = _studentBankingService.GetById(id.Value);
            StudentDocument studentDocument = _studentDocumentService.GetById(id.Value);
            StudentHostel studentHostel = _studentHostelService.GetById(id.Value);
            StudentTransport studentTransport = _studentTransportService.GetById(id.Value);

            StudentAdmissionViewModel viewmodel = new StudentAdmissionViewModel
            {
                AdmissionDate = studentAdmission.AdmissionDate,
                AdmissionNumber = studentAdmission.AdmissionNumber,
                AsOnDate = studentAdmission.AsOnDate,
                CategoryId = studentAdmission.CategoryId,
                CategoryName = studentAdmission.CategoryName.CategoryName,
                Caste = studentAdmission.Caste,
                ClassId = studentAdmission.ClassNameId,
                ClassName = studentAdmission.ClassName.ClassName,
                FirstName = studentAdmission.FirstName,
                LastName = studentAdmission.LastName,
                DateOfBirth = studentAdmission.DateOfBirth,
                BloodGroupId = studentAdmission.BloodGroupId,
                BloodGroupName = studentAdmission.BloodGroupName.BloodGroupName,
                CurrentAddress = studentAdmission.CurrentAddress,
                Email = studentAdmission.Email,
                FatherContact = studentAdmission.FatherContact,
                FatherName = studentAdmission.FatherName,
                FatherOccupation = studentAdmission.FatherOccupation,
                FatherPhone = studentAdmission.FatherPhone,
                FatherPhoto = studentAdmission.FatherPhoto,
                GenderId = studentAdmission.GenderId,
                GenderName = studentAdmission.GenderName.GenderName,
                GuardianAddress = studentAdmission.GuardianAddress,
                GuardianEmail = studentAdmission.GuardianEmail,
                GuardianName = studentAdmission.GuardianName,
                GuardianOccupation = studentAdmission.GuardianOccupation,
                GuardianPhone = studentAdmission.GuardianPhone,
                GuardianPhoto = studentAdmission.GuardianPhoto,
                GuardianRelation = studentAdmission.GuardianRelation,
                GuardianType = studentAdmission.GuardianType,
                Height = studentAdmission.Height,
                Weight = studentAdmission.Weight,
                Religion = studentAdmission.Religion,
                Mobile = studentAdmission.Mobile,
                MotherName = studentAdmission.MotherName,
                MotherOccupation = studentAdmission.MotherOccupation,
                MotherPhone = studentAdmission.MotherPhone,
                MotherPhoto = studentAdmission.MotherPhoto,
                PermanentAddress = studentAdmission.PermanentAddress,
                RollNumber = studentAdmission.RollNumber,
                SectionId = studentAdmission.SectionNameId,
                StudentHouseId = studentAdmission.StudentHouseId,
                StudentHouseName = studentAdmission.StudentHouseName.StudentHouseName,
                StudentPhoto = studentAdmission.StudentPhoto,
                VehicleRouteId = studentTransport.VehicleRouteId,
                PreviousSchoolDetails = studentBanking.PreviousSchoolDetails,
                Id = studentAdmission.Id,

                HostelId = studentHostel.HostelId,
                HostelName = studentHostel.HostelName.HostelName,
                RoomId = studentHostel.RoomNameId,

                Document1Path = studentDocument.Document1Path,
                Document1Title = studentDocument.Document1Title,
                Document2Path = studentDocument.Document2Path,
                Document2Title = studentDocument.Document2Title,
                Document3Path = studentDocument.Document3Path,
                Document3Title = studentDocument.Document3Title,
                Document4Path = studentDocument.Document4Path,
                Document4TItle = studentDocument.Document4TItle,

                BankAccountNumber = studentBanking.BankAccountNumber,
                BankName = studentBanking.BankName,
                CIFCode = studentBanking.CIFCode,
                IFSCCode = studentBanking.IFSCCode,
                LocalIdentificationNumber = studentBanking.LocalIdentificationNumber,
                NationalIdentificationNumber = studentBanking.NationalIdentificationNumber,
                Note = studentBanking.Note
            };

            if (viewmodel == null)
            {
                return HttpNotFound();
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "GenderName");
            ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "ClassName", "ClassName");
            ViewBag.SectionId = new SelectList(_SectionService.GetAll(), "Id", "SectionName");
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "CategoryName");
            ViewBag.BloodGroupId = new SelectList(_bloodGroupService.GetAll(), "Id", "BloodGroupName");
            ViewBag.StudentHouseId = new SelectList(_studentHouseService.GetAll(), "Id", "StudentHouseName");
            ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName");
            ViewBag.HostelRoomId = new SelectList(_hostelRoomService.GetAll(), "Id", "RoomNumberOrName");
            ViewBag.VehicleRouteId = new SelectList(_vehicleRouteService.GetAll(), "Id", "Vehicle");

            return View(new StudentAdmissionViewModel());
        }

        

        [HttpPost]
        public ActionResult Create(StudentAdmissionViewModel viewmodel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                StudentAdmission studentAdmission = new StudentAdmission
                {
                    Id = viewmodel.Id,
                    AdmissionDate = viewmodel.AdmissionDate,
                    AdmissionNumber = viewmodel.AdmissionNumber,
                    AsOnDate = viewmodel.AsOnDate,
                    BloodGroupId = viewmodel.BloodGroupId,
                    Caste = viewmodel.Caste,
                    CategoryId = viewmodel.CategoryId,
                    ClassNameId = viewmodel.ClassId,
                    CurrentAddress = viewmodel.CurrentAddress,
                    DateOfBirth = viewmodel.DateOfBirth,
                    Email = viewmodel.Email,
                    FirstName = viewmodel.FirstName,
                    GenderId = viewmodel.GenderId,
                    Height = viewmodel.Height,
                    LastName = viewmodel.LastName,
                    Mobile = viewmodel.Mobile,
                    PermanentAddress = viewmodel.PermanentAddress,
                    Religion = viewmodel.Religion,
                    RollNumber = viewmodel.RollNumber,
                    SectionNameId = viewmodel.SectionId,
                    StudentHouseId = viewmodel.StudentHouseId,
                    StudentPhoto = "~/UploadContent/profileimages/" + file.FileName,
                    Weight = viewmodel.Weight,
                    FatherContact = viewmodel.FatherContact,
                    MotherName = viewmodel.MotherName,
                    FatherName = viewmodel.FatherName,
                    FatherPhone = viewmodel.FatherPhone,
                    FatherPhoto = viewmodel.FatherPhoto,
                    GuardianAddress = viewmodel.GuardianAddress,
                    GuardianEmail = viewmodel.GuardianEmail,
                    GuardianName = viewmodel.GuardianName,
                    GuardianOccupation = viewmodel.GuardianOccupation,
                    GuardianPhone = viewmodel.GuardianPhone,
                    GuardianPhoto = viewmodel.GuardianPhoto,
                    GuardianRelation = viewmodel.GuardianRelation,
                    GuardianType = viewmodel.GuardianType,
                    MotherOccupation = viewmodel.MotherOccupation,
                    MotherPhone = viewmodel.MotherPhone,
                    MotherPhoto = viewmodel.MotherPhoto,
                };

                string path = Path.Combine(Server.MapPath("~/UploadContent/profileimages/"), Path.GetFileName(file.FileName));
                file.SaveAs(path);

                _studentAdmissionService.Create(studentAdmission);

                StudentBanking studentBanking = new StudentBanking
                {
                    StudentId = studentAdmission.Id,
                    BankAccountNumber = viewmodel.BankAccountNumber,
                    IFSCCode = viewmodel.IFSCCode,
                    LocalIdentificationNumber = viewmodel.LocalIdentificationNumber,
                    NationalIdentificationNumber = viewmodel.NationalIdentificationNumber,
                    Note = viewmodel.Note,
                    BankName = viewmodel.BankName,
                    CIFCode = viewmodel.CIFCode,
                    PreviousSchoolDetails = viewmodel.PreviousSchoolDetails,
                    
                };

                StudentDocument studentDocument = new StudentDocument
                {
                    Document1Path = viewmodel.Document1Path,
                    Document2Path = viewmodel.Document2Path,
                    Document3Path = viewmodel.Document3Path,
                    Document4Path = viewmodel.Document4Path,
                    Document1Title = viewmodel.Document1Title,
                    Document2Title = viewmodel.Document2Title,
                    Document3Title = viewmodel.Document3Title,
                    Document4TItle = viewmodel.Document4TItle,
                    StudentId = studentAdmission.Id
                };

                StudentHostel studentHostel = new StudentHostel
                {
                    HostelId = viewmodel.HostelId,
                    RoomNameId = viewmodel.RoomId,
                    StudentId = studentAdmission.Id
                };

                StudentTransport studentTransport = new StudentTransport
                {
                    StudentId = studentAdmission.Id,
                    VehicleRouteId = viewmodel.VehicleRouteId
                };

                
                _studentBankingService.Create(studentBanking);
                _studentDocumentService.Create(studentDocument);
                _studentHostelService.Create(studentHostel);
                _studentTransportService.Create(studentTransport);

                StudentAuthentication studentLogin = new StudentAuthentication
                {
                    StudentId = studentAdmission.Id,
                    Username = "std" + studentAdmission.Id,
                    Password = Helper.GetRandomPassword(5),
                    Status = true
                };

                _studentAuthenticationService.Create(studentLogin);
                
                return RedirectToAction("Create", "Student", new { area = "student" });
            }

            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "GenderName", viewmodel.GenderId);
            ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "Id", "ClassName", viewmodel.ClassId);
            ViewBag.SectionId = new SelectList(_SectionService.GetAll(), "Id", "SectionName", viewmodel.SectionId);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "CategoryName", viewmodel.CategoryId);
            ViewBag.BloodGroupId = new SelectList(_bloodGroupService.GetAll(), "Id", "BloodGroupName", viewmodel.BloodGroupId);
            ViewBag.StudentHouseId = new SelectList(_studentHouseService.GetAll(), "Id", "StudentHouseName", viewmodel.StudentHouseId);
            ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName", viewmodel.HostelId);
            ViewBag.HostelRoomId = new SelectList(_hostelRoomService.GetAll(), "Id", "RoomNumberOrName", viewmodel.RoomId);
            ViewBag.VehicleRouteId = new SelectList(_vehicleRouteService.GetAll(), "Id", "Vehicle", viewmodel.VehicleRouteId);

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            IEnumerable<StudentAdmissionViewModel> students = _studentAdmissionService.GetAll().Select(s => new StudentAdmissionViewModel
            {
                AdmissionNumber = s.AdmissionNumber,
                FirstName = s.FirstName,
                LastName = s.LastName,
                ClassId = s.ClassNameId,
                ClassName = s.ClassName.ClassName,
                SectionId = s.SectionNameId,
                FatherName = s.FatherName,
                DateOfBirth = s.DateOfBirth,
                GenderId = s.GenderId,
                GenderName = s.GenderName.GenderName,
                CategoryId = s.CategoryId,
                CategoryName = s.CategoryName.CategoryName,
                Mobile = s.Mobile,
                Id = s.Id
            });

            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentAdmission studentAdmission = _studentAdmissionService.GetById(id.Value);
            StudentBanking studentBanking = _studentBankingService.GetById(id.Value);
            StudentDocument studentDocument = _studentDocumentService.GetById(id.Value);
            StudentHostel studentHostel = _studentHostelService.GetById(id.Value);
            StudentTransport studentTransport = _studentTransportService.GetById(id.Value);

            StudentAdmissionViewModel viewmodel = new StudentAdmissionViewModel
            {
                AdmissionDate = studentAdmission.AdmissionDate,
                AdmissionNumber = studentAdmission.AdmissionNumber,
                AsOnDate = studentAdmission.AsOnDate,
                CategoryId = studentAdmission.CategoryId,
                CategoryName = studentAdmission.CategoryName.CategoryName,
                Caste = studentAdmission.Caste,
                ClassId = studentAdmission.ClassNameId,
                ClassName = studentAdmission.ClassName.ClassName,
                FirstName = studentAdmission.FirstName,
                LastName = studentAdmission.LastName,
                DateOfBirth = studentAdmission.DateOfBirth,
                BloodGroupId = studentAdmission.BloodGroupId,
                BloodGroupName = studentAdmission.BloodGroupName.BloodGroupName,
                CurrentAddress = studentAdmission.CurrentAddress,
                Email = studentAdmission.Email,
                FatherContact = studentAdmission.FatherContact,
                FatherName = studentAdmission.FatherName,
                FatherOccupation = studentAdmission.FatherOccupation,
                FatherPhone = studentAdmission.FatherPhone,
                FatherPhoto = studentAdmission.FatherPhoto,
                GenderId = studentAdmission.GenderId,
                GenderName = studentAdmission.GenderName.GenderName,
                GuardianAddress = studentAdmission.GuardianAddress,
                GuardianEmail = studentAdmission.GuardianEmail,
                GuardianName = studentAdmission.GuardianName,
                GuardianOccupation = studentAdmission.GuardianOccupation,
                GuardianPhone = studentAdmission.GuardianPhone,
                GuardianPhoto = studentAdmission.GuardianPhoto,
                GuardianRelation = studentAdmission.GuardianRelation,
                GuardianType = studentAdmission.GuardianType,
                Height = studentAdmission.Height,
                Weight = studentAdmission.Weight,
                Religion = studentAdmission.Religion,
                Mobile = studentAdmission.Mobile,
                MotherName = studentAdmission.MotherName,
                MotherOccupation = studentAdmission.MotherOccupation,
                MotherPhone = studentAdmission.MotherPhone,
                MotherPhoto = studentAdmission.MotherPhoto,
                PermanentAddress = studentAdmission.PermanentAddress,
                RollNumber = studentAdmission.RollNumber,
                SectionId = studentAdmission.SectionNameId,
                StudentHouseId = studentAdmission.StudentHouseId,
                StudentHouseName = studentAdmission.StudentHouseName.StudentHouseName,
                StudentPhoto = studentAdmission.StudentPhoto,
                VehicleRouteId = studentTransport.VehicleRouteId,
                PreviousSchoolDetails = studentBanking.PreviousSchoolDetails,
                Id = studentAdmission.Id,

                HostelId = studentHostel.HostelId,
                HostelName = studentHostel.HostelName.HostelName,
                RoomId = studentHostel.RoomNameId,

                Document1Path = studentDocument.Document1Path,
                Document1Title = studentDocument.Document1Title,
                Document2Path = studentDocument.Document2Path,
                Document2Title = studentDocument.Document2Title,
                Document3Path = studentDocument.Document3Path,
                Document3Title = studentDocument.Document3Title,
                Document4Path = studentDocument.Document4Path,
                Document4TItle = studentDocument.Document4TItle,

                BankAccountNumber = studentBanking.BankAccountNumber,
                BankName = studentBanking.BankName,
                CIFCode = studentBanking.CIFCode,
                IFSCCode = studentBanking.IFSCCode,
                LocalIdentificationNumber = studentBanking.LocalIdentificationNumber,
                NationalIdentificationNumber = studentBanking.NationalIdentificationNumber,
                Note = studentBanking.Note
            };

            if (viewmodel == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "GenderName", viewmodel.GenderId);
            ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "Id", "ClassName", viewmodel.ClassId);
            ViewBag.SectionId = new SelectList(_SectionService.GetAll(), "Id", "SectionName", viewmodel.SectionId);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "CategoryName", viewmodel.CategoryId);
            ViewBag.BloodGroupId = new SelectList(_bloodGroupService.GetAll(), "Id", "BloodGroupName", viewmodel.BloodGroupId);
            ViewBag.StudentHouseId = new SelectList(_studentHouseService.GetAll(), "Id", "StudentHouseName", viewmodel.StudentHouseId);
            ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName", viewmodel.HostelId);
            ViewBag.HostelRoomId = new SelectList(_hostelRoomService.GetAll(), "Id", "RoomNumberOrName", viewmodel.RoomId);
            ViewBag.VehicleRouteId = new SelectList(_vehicleRouteService.GetAll(), "Id", "Vehicle", viewmodel.VehicleRouteId);

            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentAdmissionViewModel viewmodel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                StudentAdmission sa = _studentAdmissionService.GetById(viewmodel.Id);
                StudentBanking sb = _studentBankingService.GetById(viewmodel.Id);
                StudentDocument sd = _studentDocumentService.GetById(viewmodel.Id);
                StudentHostel sh = _studentHostelService.GetById(viewmodel.Id);
                StudentTransport st = _studentTransportService.GetById(viewmodel.Id);

                sa.AdmissionDate = viewmodel.AdmissionDate;
                sa.AdmissionNumber = viewmodel.AdmissionNumber;
                sa.AsOnDate = viewmodel.AsOnDate;
                sa.CategoryId = viewmodel.CategoryId;
                sa.CategoryName.CategoryName = viewmodel.CategoryName;
                sa.Caste = viewmodel.Caste;
                sa.ClassNameId = viewmodel.ClassId;
                sa.ClassName.ClassName = viewmodel.ClassName;
                sa.FirstName = viewmodel.FirstName;
                sa.LastName = viewmodel.LastName;
                sa.DateOfBirth = viewmodel.DateOfBirth;
                sa.BloodGroupId = viewmodel.BloodGroupId;
                sa.BloodGroupName.BloodGroupName = viewmodel.BloodGroupName;
                sa.CurrentAddress = viewmodel.CurrentAddress;
                sa.Email = viewmodel.Email;
                sa.FatherContact = viewmodel.FatherContact;
                sa.FatherName = viewmodel.FatherName;
                sa.FatherOccupation = viewmodel.FatherOccupation;
                sa.FatherPhone = viewmodel.FatherPhone;
                sa.FatherPhoto = viewmodel.FatherPhoto;
                sa.GenderId = viewmodel.GenderId;
                sa.GenderName.GenderName = viewmodel.GenderName;
                sa.GuardianAddress = viewmodel.GuardianAddress;
                sa.GuardianEmail = viewmodel.GuardianEmail;
                sa.GuardianName = viewmodel.GuardianName;
                sa.GuardianOccupation = viewmodel.GuardianOccupation;
                sa.GuardianPhone = viewmodel.GuardianPhone;
                sa.GuardianPhoto = viewmodel.GuardianPhoto;
                sa.GuardianRelation = viewmodel.GuardianRelation;
                sa.GuardianType = viewmodel.GuardianType;
                sa.Height = viewmodel.Height;
                sa.Weight = viewmodel.Weight;
                sa.Religion = viewmodel.Religion;
                sa.Mobile = viewmodel.Mobile;
                sa.MotherName = viewmodel.MotherName;
                sa.MotherOccupation = viewmodel.MotherOccupation;
                sa.MotherPhone = viewmodel.MotherPhone;
                sa.MotherPhoto = viewmodel.MotherPhoto;
                sa.PermanentAddress = viewmodel.PermanentAddress;
                sa.RollNumber = viewmodel.RollNumber;
                sa.SectionNameId = viewmodel.SectionId;
                sa.StudentHouseId = viewmodel.StudentHouseId;
                sa.StudentHouseName.StudentHouseName = viewmodel.StudentHouseName;
                sa.StudentPhoto = viewmodel.StudentPhoto;


                sh.HostelId = viewmodel.HostelId;
                sh.HostelName.HostelName = viewmodel.HostelName;
                sh.RoomNameId = viewmodel.RoomId;

                sd.Document1Path = viewmodel.Document1Path;
                sd.Document1Title = viewmodel.Document1Title;
                sd.Document2Path = viewmodel.Document2Path;
                sd.Document2Title = viewmodel.Document2Title;
                sd.Document3Path = viewmodel.Document3Path;
                sd.Document3Title = viewmodel.Document3Title;
                sd.Document4Path = viewmodel.Document4Path;
                sd.Document4TItle = viewmodel.Document4TItle;

                sb.BankAccountNumber = viewmodel.BankAccountNumber;
                sb.BankName = viewmodel.BankName;
                sb.CIFCode = viewmodel.CIFCode;
                sb.IFSCCode = viewmodel.IFSCCode;
                sb.LocalIdentificationNumber = viewmodel.LocalIdentificationNumber;
                sb.NationalIdentificationNumber = viewmodel.NationalIdentificationNumber;
                sb.Note = viewmodel.Note;

                _studentAdmissionService.Update(sa);
                _studentBankingService.Update(sb);
                _studentDocumentService.Update(sd);
                _studentHostelService.Update(sh);
                _studentTransportService.Update(st);

                if (sa.Id != null)
                {
                    RedirectToAction("Search");
                }
            }

            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "GenderName", viewmodel.GenderId);
            ViewBag.ClassId = new SelectList(_schoolClassService.GetAll(), "Id", "ClassName", viewmodel.ClassId);
            ViewBag.SectionId = new SelectList(_SectionService.GetAll(), "Id", "SectionName", viewmodel.SectionId);
            ViewBag.CategoryId = new SelectList(_categoryService.GetAll(), "Id", "CategoryName", viewmodel.CategoryId);
            ViewBag.BloodGroupId = new SelectList(_bloodGroupService.GetAll(), "Id", "BloodGroupName", viewmodel.BloodGroupId);
            ViewBag.StudentHouseId = new SelectList(_studentHouseService.GetAll(), "Id", "StudentHouseName", viewmodel.StudentHouseId);
            ViewBag.HostelId = new SelectList(_hostelService.GetAll(), "Id", "HostelName", viewmodel.HostelId);
            ViewBag.HostelRoomId = new SelectList(_hostelRoomService.GetAll(), "Id", "RoomNumberOrName", viewmodel.RoomId);
            ViewBag.VehicleRouteId = new SelectList(_vehicleRouteService.GetAll(), "Id", "Vehicle", viewmodel.VehicleRouteId);

            return RedirectToAction("Search", "Student", new { id = viewmodel.Id, @area = "student" });
        }

        public JsonResult GetStudentData()
        {
            IEnumerable<StudentAuthentication> student = _studentAuthenticationService.GetAll().Select(s => new StudentAuthentication
            {
                Id = s.Id,
                Username = s.Username,
                Password = s.Password,
                Status = s.Status
            });

            return Json(student, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult StudentReport()
        {
            var studentAdmission = _studentAdmissionService.GetAll();
            var studentId = studentAdmission.Select(x => x.Id).Distinct();
            var studentBanking = _studentBankingService.GetById(Convert.ToInt32(studentId));

            

            return View();
        }

    }
}