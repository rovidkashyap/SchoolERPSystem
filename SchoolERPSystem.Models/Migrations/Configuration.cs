namespace SchoolERPSystem.Models.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SchoolERPSystem.Models.Authentication;
    using SchoolERPSystem.Models.Dependencies;
    using SchoolERPSystem.Models.Dependencies.SettingDependencies;
    using SchoolERPSystem.Models.Dependencies.StudentDependencies;
    using SchoolERPSystem.Models.Hostel;
    using SchoolERPSystem.Models.Setting;
    using SchoolERPSystem.Models.StaffModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolERPSystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SchoolERPSystem.Models.ApplicationDbContext";
        }

        protected override void Seed(SchoolERPSystem.Models.ApplicationDbContext context)
        {
            IList<Gender> genders = new List<Gender>();
            genders.Add(new Gender { GenderName = "Male" });
            genders.Add(new Gender { GenderName = "Female" });
            genders.Add(new Gender { GenderName = "Other" });
            context.Genders.AddRange(genders);
            context.SaveChanges();

            IList<Department> departments = new List<Department>();
            departments.Add(new Department { Name = "Academics", IsActive = true });
            departments.Add(new Department { Name = "Library", IsActive = true });
            departments.Add(new Department { Name = "Sports", IsActive = true });
            departments.Add(new Department { Name = "Science", IsActive = true });
            departments.Add(new Department { Name = "Commerce", IsActive = true });
            departments.Add(new Department { Name = "Accounts", IsActive = true });
            departments.Add(new Department { Name = "Exams", IsActive = true });
            departments.Add(new Department { Name = "Admin", IsActive = true });
            departments.Add(new Department { Name = "Superdmin", IsActive = true });

            context.Departments.AddRange(departments);
            context.SaveChanges();

            IList<Designation> designations = new List<Designation>();
            designations.Add(new Designation { Name = "Accountant", IsActive = true });
            designations.Add(new Designation { Name = "Admin", IsActive = true });
            designations.Add(new Designation { Name = "Faculty", IsActive = true });
            designations.Add(new Designation { Name = "Librarian", IsActive = true });
            designations.Add(new Designation { Name = "Receptionist", IsActive = true });
            designations.Add(new Designation { Name = "Principal", IsActive = true });
            designations.Add(new Designation { Name = "Director", IsActive = true });
            designations.Add(new Designation { Name = "Superadmin", IsActive = true });

            context.Designations.AddRange(designations);
            context.SaveChanges();

            IList<MaritalStatus> maritalStatus = new List<MaritalStatus>();
            maritalStatus.Add(new MaritalStatus { MaritalStatusName = "Single" });
            maritalStatus.Add(new MaritalStatus { MaritalStatusName = "Married" });
            maritalStatus.Add(new MaritalStatus { MaritalStatusName = "Widowed" });
            maritalStatus.Add(new MaritalStatus { MaritalStatusName = "Seperated" });
            maritalStatus.Add(new MaritalStatus { MaritalStatusName = "Not Specified" });
            context.MaritalStatus.AddRange(maritalStatus);
            context.SaveChanges();

            IList<ContractType> contractType = new List<ContractType>();
            contractType.Add(new ContractType { Name = "Permanent", IsActive = true });
            contractType.Add(new ContractType { Name = "Contract Basis", IsActive = true });
            context.ContractTypes.AddRange(contractType);
            context.SaveChanges();

            IList<Currency> currency = new List<Currency>();
            currency.Add(new Currency { CurrencyName = "USD" });
            currency.Add(new Currency { CurrencyName = "INR" });
            context.Currencies.AddRange(currency);
            context.SaveChanges();

            IList<Language> language = new List<Language>();
            language.Add(new Language { LanguageName = "English" });
            language.Add(new Language { LanguageName = "Spanish" });
            context.Languages.AddRange(language);
            context.SaveChanges();

            IList<Timezone> timezone = new List<Timezone>();
            timezone.Add(new Timezone { TimezoneName = "UTC" });
            timezone.Add(new Timezone { TimezoneName = "GMT" });
            context.Timezones.AddRange(timezone);
            context.SaveChanges();

            IList<Session> session = new List<Session>();
            session.Add(new Session { SessionName = "2019-20" });
            session.Add(new Session { SessionName = "2020-21" });
            context.Sessions.AddRange(session);
            context.SaveChanges();

            IList<GeneralSetting> setting = new List<GeneralSetting>();
            setting.Add(new GeneralSetting { FeesDueDays = 0, SessionId = 1, LanguageId = 1, CurrencyId = 1, TimezoneId = 1 });
            context.GeneralSettings.AddRange(setting);
            context.SaveChanges();

            IList<HostelType> hostelType = new List<HostelType>();
            hostelType.Add(new HostelType { HostelTypeName = "Boys" });
            hostelType.Add(new HostelType { HostelTypeName = "Girls" });
            hostelType.Add(new HostelType { HostelTypeName = "Combined" });
            context.HostelTypes.AddRange(hostelType);
            context.SaveChanges();

            IList<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryName = "General" });
            categories.Add(new Category { CategoryName = "OBC" });
            categories.Add(new Category { CategoryName = "SC" });
            categories.Add(new Category { CategoryName = "ST" });
            categories.Add(new Category { CategoryName = "Physically Challenged" });
            context.Categories.AddRange(categories);
            context.SaveChanges();

            IList<StudentHouse> studentHouse = new List<StudentHouse>();
            studentHouse.Add(new StudentHouse { StudentHouseName = "Blue" });
            studentHouse.Add(new StudentHouse { StudentHouseName = "Green" });
            studentHouse.Add(new StudentHouse { StudentHouseName = "Red" });
            studentHouse.Add(new StudentHouse { StudentHouseName = "Yellow" });
            context.StudentHouses.AddRange(studentHouse);
            context.SaveChanges();

            IList<BloodGroup> blood = new List<BloodGroup>();
            blood.Add(new BloodGroup { BloodGroupName = "A+" });
            blood.Add(new BloodGroup { BloodGroupName = "A-" });
            blood.Add(new BloodGroup { BloodGroupName = "AB+" });
            blood.Add(new BloodGroup { BloodGroupName = "AB-" });
            blood.Add(new BloodGroup { BloodGroupName = "B+" });
            blood.Add(new BloodGroup { BloodGroupName = "B-" });
            blood.Add(new BloodGroup { BloodGroupName = "O+" });
            blood.Add(new BloodGroup { BloodGroupName = "O-" });
            context.BloodGroups.AddRange(blood);
            context.SaveChanges();

            base.Seed(context);
            createRolesandUsers();

        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Superadmin"))
            {

                // first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Superadmin";
                roleManager.Create(role);

                //Here we create a Superadmin user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "superadmin";
                user.Email = "superadmin@gmail.com";

                string userPWD = "Superadmin@123";

                var chkUser = UserManager.Create(user, userPWD);
                
                StaffProfile staffProfile = new StaffProfile
                {
                    ApplicationUserId = user.Id,
                    StaffId = "1000000",
                    RoleName = "Superadmin",
                    FirstName = "Rovid",
                    LastName = "Kashyap",
                    GenderId = 1,
                    DepartmentId = 9,
                    DesignationId = 8,
                    MaritalStatusId = 1,
                    WorkExperience = 0,
                    DateOfJoining = DateTime.Now,
                    DateOfBirth = Convert.ToDateTime("01/04/1978")
                };

                StaffBankDetails staffBankDetails = new StaffBankDetails
                {
                    ApplicationUserId = user.Id
                };

                StaffDocuments staffDocuments = new StaffDocuments
                {
                    ApplicationUserId = user.Id
                };

                StaffLeaves staffLeaves = new StaffLeaves
                {
                    ApplicationUserId = user.Id
                };

                StaffPayroll staffPayroll = new StaffPayroll
                {
                    ApplicationUserId = user.Id,
                    ContractTypeId = 1
                };

                StaffProfileImage staffProfileImage  = new StaffProfileImage
                {
                    ApplicationUserId = user.Id
                };

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    context.StaffProfiles.AddOrUpdate(staffProfile);
                    context.StaffBankDetails.AddOrUpdate(staffBankDetails);
                    context.StaffDocuments.AddOrUpdate(staffDocuments);
                    context.StaffLeaves.AddOrUpdate(staffLeaves);
                    context.StaffPayrolls.AddOrUpdate(staffPayroll);
                    context.StaffProfileImages.AddOrUpdate(staffProfileImage);
                    context.SaveChanges();
                    var result1 = UserManager.AddToRole(user.Id, "Superadmin");
                    
                }
            }

            // creating Creating Admin role 
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin User who will almost maintain the website

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";

                string userPWD = "Admin@123";

                var chkUser = UserManager.Create(user, userPWD);
                StaffProfile staffProfile = new StaffProfile
                {
                    ApplicationUserId = user.Id,
                    StaffId = "2000000",
                    RoleName = "Admin",
                    FirstName = "Ashish",
                    LastName = "Raghuvanshi",
                    GenderId = 1,
                    DepartmentId = 8,
                    DesignationId = 2,
                    MaritalStatusId = 1,
                    WorkExperience = 0,
                    DateOfJoining = DateTime.Now,
                    DateOfBirth = Convert.ToDateTime("09/01/1975")
                };

                StaffBankDetails staffBankDetails = new StaffBankDetails
                {
                    ApplicationUserId = user.Id
                };

                StaffDocuments staffDocuments = new StaffDocuments
                {
                    ApplicationUserId = user.Id
                };

                StaffLeaves staffLeaves = new StaffLeaves
                {
                    ApplicationUserId = user.Id
                };

                StaffPayroll staffPayroll = new StaffPayroll
                {
                    ApplicationUserId = user.Id,
                    ContractTypeId = 1
                };

                StaffProfileImage staffProfileImage = new StaffProfileImage
                {
                    ApplicationUserId = user.Id
                };

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    context.StaffProfiles.AddOrUpdate(staffProfile);
                    context.StaffBankDetails.AddOrUpdate(staffBankDetails);
                    context.StaffDocuments.AddOrUpdate(staffDocuments);
                    context.StaffLeaves.AddOrUpdate(staffLeaves);
                    context.StaffPayrolls.AddOrUpdate(staffPayroll);
                    context.StaffProfileImages.AddOrUpdate(staffProfileImage);
                    context.SaveChanges();
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                    
                }
            }

            // creating Creating Teacher role 
            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

            }

            // creating Creating Accountant role 
            if (!roleManager.RoleExists("Accountant"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Accountant";
                roleManager.Create(role);

            }

            // creating Creating Librarian role 
            if (!roleManager.RoleExists("Librarian"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Librarian";
                roleManager.Create(role);

            }

            // creating Creating Receptionist role 
            if (!roleManager.RoleExists("Recptionist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Receptionist";
                roleManager.Create(role);

            }
        }
    }
}
