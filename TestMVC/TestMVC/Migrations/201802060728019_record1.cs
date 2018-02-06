namespace TestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class record1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.employee");
        }
    }
}
