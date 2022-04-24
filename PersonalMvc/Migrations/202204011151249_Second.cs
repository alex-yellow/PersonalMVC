namespace PersonalMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professions", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Professions", "DepartmentId");
            AddForeignKey("dbo.Professions", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professions", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Professions", new[] { "DepartmentId" });
            DropColumn("dbo.Professions", "DepartmentId");
        }
    }
}
