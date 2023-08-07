namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoradaKupacFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Kupacs", name: "TipClanstvaId_Id", newName: "TipClanstva_Id");
            RenameColumn(table: "dbo.Kupacs", name: "TipKupcaId_Id", newName: "TipKupca_Id");
            RenameIndex(table: "dbo.Kupacs", name: "IX_TipClanstvaId_Id", newName: "IX_TipClanstva_Id");
            RenameIndex(table: "dbo.Kupacs", name: "IX_TipKupcaId_Id", newName: "IX_TipKupca_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Kupacs", name: "IX_TipKupca_Id", newName: "IX_TipKupcaId_Id");
            RenameIndex(table: "dbo.Kupacs", name: "IX_TipClanstva_Id", newName: "IX_TipClanstvaId_Id");
            RenameColumn(table: "dbo.Kupacs", name: "TipKupca_Id", newName: "TipKupcaId_Id");
            RenameColumn(table: "dbo.Kupacs", name: "TipClanstva_Id", newName: "TipClanstvaId_Id");
        }
    }
}
