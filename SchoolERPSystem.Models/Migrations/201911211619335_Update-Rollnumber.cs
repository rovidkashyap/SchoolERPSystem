namespace SchoolERPSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRollnumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentAdmissions", "RollNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAdmissions", "RollNumber", c => c.Long());
        }
    }
}
