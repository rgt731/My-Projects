namespace PikYak.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YakViewModelMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Yaks", newName: "YakClasses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.YakClasses", newName: "Yaks");
        }
    }
}
