namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HadTo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yaks", "Positivity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yaks", "Positivity");
        }
    }
}
