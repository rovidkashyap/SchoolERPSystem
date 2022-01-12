using Microsoft.AspNet.Identity.EntityFramework;
using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Models.Common;
using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Models.Setting;
using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Models.Transport;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolERPSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<StudentAuthentication> StudentAuthentication { get; set; }

        //Inventory DbSet
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }

        //public DbSet<ItemStock> ItemStocks { get; set; }
        public DbSet<ItemStore> ItemStores { get; set; }
        public DbSet<ItemSupplier> ItemSuppliers { get; set; }

        //Academics Model DbSet
        public DbSet<Section> Sections { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<ClassSection> ClassSections { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        //public DbSet<SubjectTypes> SubjectTypes { get; set; }
        //public DbSet<TeacherClass> TeacherClasses { get; set; }
        //public DbSet<TeacherSubjects> TeacherSubjects { get; set; }

        //Reception Model DbSet
        public DbSet<AdmissionEnquiry> AdmissionEnquiries { get; set; }
        public DbSet<ComplainDetails> ComplainDetails { get; set; }
        public DbSet<ComplainType> ComplaintTypes { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<VisitorDetails> VisitorDetails { get; set; }
        public DbSet<PhoneCallLog> PhoneCallLogs { get; set; }
        public DbSet<PostalDispatch> PostalDispatches { get; set; }
        public DbSet<PostalReceive> PostalReceives { get; set; }

        //Staff Model Dependency DbSet
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }


        //Staff Model DbSet
        public DbSet<StaffProfile> StaffProfiles { get; set; }
        public DbSet<StaffBankDetails> StaffBankDetails { get; set; }
        public DbSet<StaffDocuments> StaffDocuments { get; set; }
        public DbSet<StaffLeaves> StaffLeaves { get; set; }
        public DbSet<StaffPayroll> StaffPayrolls { get; set; }
        public DbSet<StaffProfileImage> StaffProfileImages { get; set; }
        public DbSet<StaffAttendance> StaffAttendance { get; set; }

        //Income DbSet Model
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<Income.Income> Incomes { get; set; }

        //Expense DbSet Model
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense.Expense> Expenses { get; set; }

        // Settings DbSet Model
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Timezone> Timezones { get; set; }

        // Transport DbSet Model
        public DbSet<Route> Routes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleRoute> VehicleRoutes { get; set; }

        // Hostel DbSet Model
        public DbSet<Hostel.Hostel> Hostels { get; set; }
        public DbSet<HostelType> HostelTypes { get; set; }
        public DbSet<HostelRoom> HostelRooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        // Student Dependencies DbSet
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StudentHouse> StudentHouses { get; set; }

        // Student DbSet Model
        public DbSet<StudentAdmission> StudentAdmissions { get; set; }
        public DbSet<StudentBanking> StudentBankings { get; set; }
        public DbSet<StudentDocument> StudentDocuments { get; set; }
        public DbSet<StudentHostel> StudentHostels { get; set; }
        public DbSet<StudentTransport> StudentTransports { get; set; }

        // General Setting DbSet
        public DbSet<GeneralSetting> GeneralSettings { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
