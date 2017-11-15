namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Details3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Details", "UserId");
        }
    }
}
