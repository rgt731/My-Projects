namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSentiment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yaks", "Confidence", c => c.Double(nullable: false));
            AddColumn("dbo.Yaks", "Sentiment", c => c.String());
            DropColumn("dbo.Yaks", "Positivity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yaks", "Positivity", c => c.Double(nullable: false));
            DropColumn("dbo.Yaks", "Sentiment");
            DropColumn("dbo.Yaks", "Confidence");
        }
    }
}
