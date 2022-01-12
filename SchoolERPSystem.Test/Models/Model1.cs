namespace SchoolERPSystem.Test.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<schoolclass> schoolclasses { get; set; }
        public virtual DbSet<section> sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<schoolclass>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<section>()
                .Property(e => e.SectionName)
                .IsUnicode(false);
        }
    }
}
