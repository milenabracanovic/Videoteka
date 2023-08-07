namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTIpClanstva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kupacs", "TipClanstvaId_Id", c => c.Int());
            AddColumn("dbo.Kupacs", "TipKupcaId_Id", c => c.Int());
            CreateIndex("dbo.Kupacs", "TipClanstvaId_Id");
            CreateIndex("dbo.Kupacs", "TipKupcaId_Id");
            AddForeignKey("dbo.Kupacs", "TipClanstvaId_Id", "dbo.TipClanstvas", "Id");
            AddForeignKey("dbo.Kupacs", "TipKupcaId_Id", "dbo.TipKupcas", "Id");
            DropColumn("dbo.Kupacs", "TipClanstvaId");
            DropColumn("dbo.Kupacs", "TipKupcaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kupacs", "TipKupcaId", c => c.Int(nullable: false));
            AddColumn("dbo.Kupacs", "TipClanstvaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Kupacs", "TipKupcaId_Id", "dbo.TipKupcas");
            DropForeignKey("dbo.Kupacs", "TipClanstvaId_Id", "dbo.TipClanstvas");
            DropIndex("dbo.Kupacs", new[] { "TipKupcaId_Id" });
            DropIndex("dbo.Kupacs", new[] { "TipClanstvaId_Id" });
            DropColumn("dbo.Kupacs", "TipKupcaId_Id");
            DropColumn("dbo.Kupacs", "TipClanstvaId_Id");
        }
    }
}
