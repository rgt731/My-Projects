namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNumberFromYak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Likes", "YakId", c => c.Int(nullable: false));
            DropColumn("dbo.Likes", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Likes", "YakId", c => c.String());
        }
    }
}
