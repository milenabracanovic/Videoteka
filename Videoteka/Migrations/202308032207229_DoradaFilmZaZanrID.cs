namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoradaFilmZaZanrID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "ZanrId_Id", c => c.Int());
            CreateIndex("dbo.Films", "ZanrId_Id");
            AddForeignKey("dbo.Films", "ZanrId_Id", "dbo.Zanrs", "Id");
            DropColumn("dbo.Films", "ZanrId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "ZanrId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Films", "ZanrId_Id", "dbo.Zanrs");
            DropIndex("dbo.Films", new[] { "ZanrId_Id" });
            DropColumn("dbo.Films", "ZanrId_Id");
        }
    }
}
