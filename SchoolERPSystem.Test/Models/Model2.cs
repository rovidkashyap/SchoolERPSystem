namespace SchoolERPSystem.Test.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<StaffAttendance> StaffAttendances { get; set; }
        public virtual DbSet<StaffProfile> StaffProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffAttendance>()
                .Property(e => e.Attendance)
                .IsUnicode(false);

            modelBuilder.Entity<StaffAttendance>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<StaffProfile>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<StaffProfile>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<StaffProfile>()
                .HasMany(e => e.StaffAttendances)
                .WithOptional(e => e.StaffProfile)
                .HasForeignKey(e => e.StaffId);
        }
    }
}
