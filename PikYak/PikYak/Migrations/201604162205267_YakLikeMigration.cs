namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YakLikeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Positivity = c.Double(nullable: false),
                        PictureURL = c.String(),
                        ReplyToYakId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Likes", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Likes", "Number");
            DropTable("dbo.Yaks");
        }
    }
}
