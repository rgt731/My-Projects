namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yaks", "likes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yaks", "likes");
        }
    }
}
