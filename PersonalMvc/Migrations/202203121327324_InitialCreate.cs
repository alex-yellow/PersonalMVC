namespace PersonalMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProfessionId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .Index(t => t.ProfessionId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Personals", new[] { "DepartmentId" });
            DropIndex("dbo.Personals", new[] { "ProfessionId" });
            DropTable("dbo.Professions");
            DropTable("dbo.Personals");
            DropTable("dbo.Departments");
        }
    }
}
