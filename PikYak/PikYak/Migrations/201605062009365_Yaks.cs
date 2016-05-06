namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yaks : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.YakClasses", newName: "Yaks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Yaks", newName: "YakClasses");
        }
    }
}
