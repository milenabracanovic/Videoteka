namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodajAdresuTelfon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Adresa", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Telefon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Telefon");
            DropColumn("dbo.AspNetUsers", "Adresa");
        }
    }
}
