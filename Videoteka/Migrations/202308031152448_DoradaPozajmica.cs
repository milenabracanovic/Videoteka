namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoradaPozajmica : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pozajmicas", "KupacId");
            CreateIndex("dbo.Pozajmicas", "FilmId");
            AddForeignKey("dbo.Pozajmicas", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pozajmicas", "KupacId", "dbo.Kupacs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pozajmicas", "KupacId", "dbo.Kupacs");
            DropForeignKey("dbo.Pozajmicas", "FilmId", "dbo.Films");
            DropIndex("dbo.Pozajmicas", new[] { "FilmId" });
            DropIndex("dbo.Pozajmicas", new[] { "KupacId" });
        }
    }
}
