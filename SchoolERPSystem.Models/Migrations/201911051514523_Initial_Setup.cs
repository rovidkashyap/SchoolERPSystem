namespace SchoolERPSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmissionEnquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        NextFollowUpDate = c.DateTime(nullable: false),
                        Assigned = c.String(),
                        ReferenceId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        SchoolClassId = c.Int(nullable: false),
                        NoOfChild = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.References", t => t.ReferenceId, cascadeDelete: true)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClassId, cascadeDelete: true)
                .ForeignKey("dbo.Sources", t => t.SourceId, cascadeDelete: true)
                .Index(t => t.ReferenceId)
                .Index(t => t.SourceId)
                .Index(t => t.SchoolClassId);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferenceName = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SourceName = c.String(),
                        SourceDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodGroupName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassNameId = c.Int(nullable: false),
                        SectionNameId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.ClassNameId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionNameId, cascadeDelete: true)
                .Index(t => t.ClassNameId)
                .Index(t => t.SectionNameId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComplainDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplainTypeId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ComplainBy = c.String(),
                        Phone = c.String(),
                        ComplainDate = c.DateTime(),
                        Description = c.String(),
                        ActionTaken = c.String(),
                        Assigned = c.String(),
                        Note = c.String(),
                        Documents = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComplainTypes", t => t.ComplainTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Sources", t => t.SourceId, cascadeDelete: true)
                .Index(t => t.ComplainTypeId)
                .Index(t => t.SourceId);
            
            CreateTable(
                "dbo.ComplainTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplainName = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        InvoiceNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Document = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseTypes", t => t.ExpenseTypeId, cascadeDelete: true)
                .Index(t => t.ExpenseTypeId);
            
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseHead = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        SchoolCode = c.String(),
                        SchoolAddress = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        SchoolEmail = c.String(),
                        SessionId = c.Int(),
                        SessionStartMonth = c.String(),
                        LanguageId = c.Int(),
                        TimezoneId = c.Int(),
                        CurrencyId = c.Int(),
                        CurrencySymbol = c.String(),
                        FeesDueDays = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.Sessions", t => t.SessionId)
                .ForeignKey("dbo.Timezones", t => t.TimezoneId)
                .Index(t => t.SessionId)
                .Index(t => t.LanguageId)
                .Index(t => t.TimezoneId)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionName = c.String(),
                        isActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timezones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimezoneName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HostelRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumberOrName = c.String(),
                        HostelId = c.Int(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                        NoOfBed = c.Int(nullable: false),
                        CostPerBed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.HostelId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.Hostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HostelName = c.String(),
                        HostelTypeId = c.Int(nullable: false),
                        Address = c.String(),
                        Intake = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HostelTypes", t => t.HostelTypeId, cascadeDelete: true)
                .Index(t => t.HostelTypeId);
            
            CreateTable(
                "dbo.HostelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HostelTypeName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomTypeName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        InvoiceNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Document = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeTypeId, cascadeDelete: true)
                .Index(t => t.IncomeTypeId);
            
            CreateTable(
                "dbo.IncomeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomeHead = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemCategoryName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.ItemStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemStoreName = c.String(),
                        ItemStockCode = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemSuppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ContactPersonName = c.String(),
                        ContactPersonPhone = c.String(),
                        ContactPersonEmail = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaritalStatusName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneCallLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Date = c.DateTime(),
                        Description = c.String(),
                        NextDate = c.DateTime(),
                        CallDuration = c.Int(nullable: false),
                        Note = c.String(),
                        CallType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostalDispatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToTitle = c.String(),
                        ReferenceNo = c.String(),
                        Address = c.String(),
                        Note = c.String(),
                        FromTitle = c.String(),
                        Date = c.DateTime(),
                        DocumentPath = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostalReceives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromTitle = c.String(),
                        ReferenceNo = c.String(),
                        Address = c.String(),
                        Note = c.String(),
                        ToTitle = c.String(),
                        Date = c.DateTime(),
                        DocumentPath = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purposes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurposeName = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteTitle = c.String(),
                        Fare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffAttendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffProfileId = c.Int(nullable: false),
                        Attendance = c.String(),
                        AttendanceDate = c.DateTime(),
                        IsHoliday = c.Boolean(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffProfiles", t => t.StaffProfileId, cascadeDelete: true)
                .Index(t => t.StaffProfileId);
            
            CreateTable(
                "dbo.StaffBankDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        AccountTitle = c.String(),
                        BankAccountNumber = c.String(),
                        BankName = c.String(),
                        IFSCCode = c.String(),
                        BankBranchName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StaffDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        ResumeName = c.String(),
                        ResumePath = c.String(),
                        JoiningLetterName = c.String(),
                        JoiningLetterPath = c.String(),
                        OtherDocumentName = c.String(),
                        OtherDocumentPath = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.StaffLeaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        MedicalLeaves = c.Int(nullable: false),
                        CasualLeaves = c.Int(nullable: false),
                        MaternityLeaves = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.StaffPayrolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        StaffEPFNo = c.String(),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContractTypeId = c.Int(nullable: false),
                        WorkShift = c.String(),
                        Location = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.ContractTypes", t => t.ContractTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ContractTypeId);
            
            CreateTable(
                "dbo.StaffProfileImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        ProfileImagePath = c.String(),
                        ProfileImageName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.StaffProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        StaffId = c.Int(nullable: false),
                        RoleName = c.String(),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        GenderId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        DateOfJoining = c.DateTime(),
                        Mobile = c.String(),
                        EmergencyContact = c.String(),
                        MaritalStatusId = c.Int(nullable: false),
                        CurrentAddress = c.String(),
                        PermanentAddress = c.String(),
                        Qualification = c.String(),
                        WorkExperience = c.Int(),
                        Note = c.String(),
                        FacebookURL = c.String(),
                        TwitterURL = c.String(),
                        LinkedInURL = c.String(),
                        InstagramURL = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatusId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.GenderId)
                .Index(t => t.MaritalStatusId);
            
            CreateTable(
                "dbo.StudentAdmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdmissionNumber = c.Long(nullable: false),
                        RollNumber = c.Long(),
                        ClassNameId = c.Int(nullable: false),
                        SectionNameId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        GenderId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Religion = c.String(),
                        Caste = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        AdmissionDate = c.DateTime(nullable: false),
                        StudentPhoto = c.String(),
                        BloodGroupId = c.Int(nullable: false),
                        StudentHouseId = c.Int(nullable: false),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AsOnDate = c.DateTime(nullable: false),
                        CurrentAddress = c.String(),
                        PermanentAddress = c.String(),
                        FatherName = c.String(),
                        FatherPhone = c.String(),
                        FatherContact = c.String(),
                        FatherPhoto = c.String(),
                        FatherOccupation = c.String(),
                        MotherName = c.String(),
                        MotherPhone = c.String(),
                        MotherOccupation = c.String(),
                        MotherPhoto = c.String(),
                        GuardianType = c.String(),
                        GuardianName = c.String(),
                        GuardianRelation = c.String(),
                        GuardianEmail = c.String(),
                        GuardianPhoto = c.String(),
                        GuardianPhone = c.String(),
                        GuardianOccupation = c.String(),
                        GuardianAddress = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SchoolClasses", t => t.ClassNameId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.StudentHouses", t => t.StudentHouseId, cascadeDelete: true)
                .Index(t => t.ClassNameId)
                .Index(t => t.GenderId)
                .Index(t => t.CategoryId)
                .Index(t => t.BloodGroupId)
                .Index(t => t.StudentHouseId);
            
            CreateTable(
                "dbo.StudentHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentHouseName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentAuthentications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentBankings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BankAccountNumber = c.String(),
                        BankName = c.String(),
                        IFSCCode = c.String(),
                        CIFCode = c.String(),
                        NationalIdentificationNumber = c.String(),
                        LocalIdentificationNumber = c.String(),
                        PreviousSchoolDetails = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Document1Title = c.String(),
                        Document1Path = c.String(),
                        Document2Title = c.String(),
                        Document2Path = c.String(),
                        Document3Title = c.String(),
                        Document3Path = c.String(),
                        Document4TItle = c.String(),
                        Document4Path = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentHostels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        HostelId = c.Int(nullable: false),
                        RoomNameId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hostels", t => t.HostelId, cascadeDelete: true)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.StudentTransports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        VehicleRouteId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleRoutes", t => t.VehicleRouteId, cascadeDelete: true)
                .Index(t => t.VehicleRouteId);
            
            CreateTable(
                "dbo.VehicleRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleNumber = c.String(),
                        VehicleModel = c.String(),
                        YearMade = c.String(),
                        DriverName = c.String(),
                        DriverLicense = c.String(),
                        DriverContact = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        SubjectType = c.String(),
                        SubjectCode = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        IPAddress = c.String(),
                        LoginDate = c.DateTime(nullable: false),
                        UserAgent = c.String(),
                        RoleName = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.VisitorDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurposeId = c.Int(nullable: false),
                        FullName = c.String(),
                        Phone = c.String(),
                        IdentiyCardNumber = c.String(),
                        NoOfPerson = c.Int(nullable: false),
                        VisitingDate = c.DateTime(),
                        InTime = c.DateTime(),
                        OutTime = c.DateTime(),
                        Note = c.String(),
                        DocumentSubmitted = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purposes", t => t.PurposeId, cascadeDelete: true)
                .Index(t => t.PurposeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitorDetails", "PurposeId", "dbo.Purposes");
            DropForeignKey("dbo.UserLogs", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentTransports", "VehicleRouteId", "dbo.VehicleRoutes");
            DropForeignKey("dbo.VehicleRoutes", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleRoutes", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.StudentHostels", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.StudentAdmissions", "StudentHouseId", "dbo.StudentHouses");
            DropForeignKey("dbo.StudentAdmissions", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.StudentAdmissions", "ClassNameId", "dbo.SchoolClasses");
            DropForeignKey("dbo.StudentAdmissions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.StudentAdmissions", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.StaffAttendances", "StaffProfileId", "dbo.StaffProfiles");
            DropForeignKey("dbo.StaffProfiles", "MaritalStatusId", "dbo.MaritalStatus");
            DropForeignKey("dbo.StaffProfiles", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.StaffProfiles", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.StaffProfiles", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.StaffProfiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StaffProfileImages", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StaffPayrolls", "ContractTypeId", "dbo.ContractTypes");
            DropForeignKey("dbo.StaffPayrolls", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StaffLeaves", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StaffDocuments", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StaffBankDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.Incomes", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.HostelRooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.HostelRooms", "HostelId", "dbo.Hostels");
            DropForeignKey("dbo.Hostels", "HostelTypeId", "dbo.HostelTypes");
            DropForeignKey("dbo.GeneralSettings", "TimezoneId", "dbo.Timezones");
            DropForeignKey("dbo.GeneralSettings", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.GeneralSettings", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GeneralSettings", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropForeignKey("dbo.ComplainDetails", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.ComplainDetails", "ComplainTypeId", "dbo.ComplainTypes");
            DropForeignKey("dbo.ClassSections", "SectionNameId", "dbo.Sections");
            DropForeignKey("dbo.ClassSections", "ClassNameId", "dbo.SchoolClasses");
            DropForeignKey("dbo.AdmissionEnquiries", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.AdmissionEnquiries", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.AdmissionEnquiries", "ReferenceId", "dbo.References");
            DropIndex("dbo.VisitorDetails", new[] { "PurposeId" });
            DropIndex("dbo.UserLogs", new[] { "ApplicationUserId" });
            DropIndex("dbo.VehicleRoutes", new[] { "VehicleId" });
            DropIndex("dbo.VehicleRoutes", new[] { "RouteId" });
            DropIndex("dbo.StudentTransports", new[] { "VehicleRouteId" });
            DropIndex("dbo.StudentHostels", new[] { "HostelId" });
            DropIndex("dbo.StudentAdmissions", new[] { "StudentHouseId" });
            DropIndex("dbo.StudentAdmissions", new[] { "BloodGroupId" });
            DropIndex("dbo.StudentAdmissions", new[] { "CategoryId" });
            DropIndex("dbo.StudentAdmissions", new[] { "GenderId" });
            DropIndex("dbo.StudentAdmissions", new[] { "ClassNameId" });
            DropIndex("dbo.StaffProfiles", new[] { "MaritalStatusId" });
            DropIndex("dbo.StaffProfiles", new[] { "GenderId" });
            DropIndex("dbo.StaffProfiles", new[] { "DepartmentId" });
            DropIndex("dbo.StaffProfiles", new[] { "DesignationId" });
            DropIndex("dbo.StaffProfiles", new[] { "ApplicationUserId" });
            DropIndex("dbo.StaffProfileImages", new[] { "ApplicationUserId" });
            DropIndex("dbo.StaffPayrolls", new[] { "ContractTypeId" });
            DropIndex("dbo.StaffPayrolls", new[] { "ApplicationUserId" });
            DropIndex("dbo.StaffLeaves", new[] { "ApplicationUserId" });
            DropIndex("dbo.StaffDocuments", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StaffBankDetails", new[] { "ApplicationUserId" });
            DropIndex("dbo.StaffAttendances", new[] { "StaffProfileId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.Incomes", new[] { "IncomeTypeId" });
            DropIndex("dbo.Hostels", new[] { "HostelTypeId" });
            DropIndex("dbo.HostelRooms", new[] { "RoomTypeId" });
            DropIndex("dbo.HostelRooms", new[] { "HostelId" });
            DropIndex("dbo.GeneralSettings", new[] { "CurrencyId" });
            DropIndex("dbo.GeneralSettings", new[] { "TimezoneId" });
            DropIndex("dbo.GeneralSettings", new[] { "LanguageId" });
            DropIndex("dbo.GeneralSettings", new[] { "SessionId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseTypeId" });
            DropIndex("dbo.ComplainDetails", new[] { "SourceId" });
            DropIndex("dbo.ComplainDetails", new[] { "ComplainTypeId" });
            DropIndex("dbo.ClassSections", new[] { "SectionNameId" });
            DropIndex("dbo.ClassSections", new[] { "ClassNameId" });
            DropIndex("dbo.AdmissionEnquiries", new[] { "SchoolClassId" });
            DropIndex("dbo.AdmissionEnquiries", new[] { "SourceId" });
            DropIndex("dbo.AdmissionEnquiries", new[] { "ReferenceId" });
            DropTable("dbo.VisitorDetails");
            DropTable("dbo.UserLogs");
            DropTable("dbo.Subjects");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleRoutes");
            DropTable("dbo.StudentTransports");
            DropTable("dbo.StudentHostels");
            DropTable("dbo.StudentDocuments");
            DropTable("dbo.StudentBankings");
            DropTable("dbo.StudentAuthentications");
            DropTable("dbo.StudentHouses");
            DropTable("dbo.StudentAdmissions");
            DropTable("dbo.StaffProfiles");
            DropTable("dbo.StaffProfileImages");
            DropTable("dbo.StaffPayrolls");
            DropTable("dbo.StaffLeaves");
            DropTable("dbo.StaffDocuments");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StaffBankDetails");
            DropTable("dbo.StaffAttendances");
            DropTable("dbo.Routes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Purposes");
            DropTable("dbo.PostalReceives");
            DropTable("dbo.PostalDispatches");
            DropTable("dbo.PhoneCallLogs");
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.ItemSuppliers");
            DropTable("dbo.ItemStores");
            DropTable("dbo.Items");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.Incomes");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.HostelTypes");
            DropTable("dbo.Hostels");
            DropTable("dbo.HostelRooms");
            DropTable("dbo.Timezones");
            DropTable("dbo.Sessions");
            DropTable("dbo.Languages");
            DropTable("dbo.GeneralSettings");
            DropTable("dbo.Genders");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Expenses");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Currencies");
            DropTable("dbo.ContractTypes");
            DropTable("dbo.ComplainTypes");
            DropTable("dbo.ComplainDetails");
            DropTable("dbo.Sections");
            DropTable("dbo.ClassSections");
            DropTable("dbo.Categories");
            DropTable("dbo.BloodGroups");
            DropTable("dbo.Sources");
            DropTable("dbo.SchoolClasses");
            DropTable("dbo.References");
            DropTable("dbo.AdmissionEnquiries");
        }
    }
}
