namespace PersonalMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Personals", "ProfessionId", "dbo.Professions");
            DropIndex("dbo.Personals", new[] { "ProfessionId" });
            DropIndex("dbo.Personals", new[] { "DepartmentId" });
            AlterColumn("dbo.Personals", "Name", c => c.String());
            AlterColumn("dbo.Personals", "ProfessionId", c => c.Int());
            AlterColumn("dbo.Personals", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Personals", "ProfessionId");
            CreateIndex("dbo.Personals", "DepartmentId");
            AddForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Personals", "ProfessionId", "dbo.Professions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Personals", new[] { "DepartmentId" });
            DropIndex("dbo.Personals", new[] { "ProfessionId" });
            AlterColumn("dbo.Personals", "DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Personals", "ProfessionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Personals", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Personals", "DepartmentId");
            CreateIndex("dbo.Personals", "ProfessionId");
            AddForeignKey("dbo.Personals", "ProfessionId", "dbo.Professions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Personals", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
