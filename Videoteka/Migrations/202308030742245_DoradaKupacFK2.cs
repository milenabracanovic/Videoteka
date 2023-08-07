namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoradaKupacFK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kupacs", "TipClanstva_Id", "dbo.TipClanstvas");
            DropForeignKey("dbo.Kupacs", "TipKupca_Id", "dbo.TipKupcas");
            DropIndex("dbo.Kupacs", new[] { "TipClanstva_Id" });
            DropIndex("dbo.Kupacs", new[] { "TipKupca_Id" });
            RenameColumn(table: "dbo.Kupacs", name: "TipClanstva_Id", newName: "TipClanstvaId");
            RenameColumn(table: "dbo.Kupacs", name: "TipKupca_Id", newName: "TipKupcaId");
            AlterColumn("dbo.Kupacs", "TipClanstvaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Kupacs", "TipKupcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kupacs", "TipKupcaId");
            CreateIndex("dbo.Kupacs", "TipClanstvaId");
            AddForeignKey("dbo.Kupacs", "TipClanstvaId", "dbo.TipClanstvas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Kupacs", "TipKupcaId", "dbo.TipKupcas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kupacs", "TipKupcaId", "dbo.TipKupcas");
            DropForeignKey("dbo.Kupacs", "TipClanstvaId", "dbo.TipClanstvas");
            DropIndex("dbo.Kupacs", new[] { "TipClanstvaId" });
            DropIndex("dbo.Kupacs", new[] { "TipKupcaId" });
            AlterColumn("dbo.Kupacs", "TipKupcaId", c => c.Int());
            AlterColumn("dbo.Kupacs", "TipClanstvaId", c => c.Int());
            RenameColumn(table: "dbo.Kupacs", name: "TipKupcaId", newName: "TipKupca_Id");
            RenameColumn(table: "dbo.Kupacs", name: "TipClanstvaId", newName: "TipClanstva_Id");
            CreateIndex("dbo.Kupacs", "TipKupca_Id");
            CreateIndex("dbo.Kupacs", "TipClanstva_Id");
            AddForeignKey("dbo.Kupacs", "TipKupca_Id", "dbo.TipKupcas", "Id");
            AddForeignKey("dbo.Kupacs", "TipClanstva_Id", "dbo.TipClanstvas", "Id");
        }
    }
}
