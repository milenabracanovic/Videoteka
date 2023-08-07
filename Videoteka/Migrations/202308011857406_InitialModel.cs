namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pozajmicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KupacId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        DatumPozajmice = c.DateTime(nullable: false),
                        DatumVracanja = c.DateTime(nullable: false),
                        Napomena = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipClanstvas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clanarina = c.Int(nullable: false),
                        TrajanjeMjeseci = c.Int(nullable: false),
                        ProcenatPopusta = c.Int(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipKupcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zanrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zanrs");
            DropTable("dbo.TipKupcas");
            DropTable("dbo.TipClanstvas");
            DropTable("dbo.Pozajmicas");
        }
    }
}
