namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dorada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zanrs", "Naziv", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zanrs", "Naziv", c => c.String());
        }
    }
}
