namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Details1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Details", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Details", "Url", c => c.String(maxLength: 100));
            AlterColumn("dbo.Details", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Details", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Details", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Details", "Description", c => c.String());
            AlterColumn("dbo.Details", "Password", c => c.String());
            AlterColumn("dbo.Details", "Email", c => c.String());
            AlterColumn("dbo.Details", "Url", c => c.String());
            AlterColumn("dbo.Details", "Name", c => c.String());
        }
    }
}
