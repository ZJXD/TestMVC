namespace TestMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class record2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.employee", "FirstName", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.employee", "LastName", c => c.String(maxLength: 5, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.employee", "LastName", c => c.String(unicode: false));
            AlterColumn("dbo.employee", "FirstName", c => c.String(unicode: false));
        }
    }
}
