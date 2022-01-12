namespace SchoolERPSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RandomNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StaffProfiles", "StaffId", c => c.String());
            AlterColumn("dbo.StudentAdmissions", "AdmissionNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAdmissions", "AdmissionNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.StaffProfiles", "StaffId", c => c.Int(nullable: false));
        }
    }
}
