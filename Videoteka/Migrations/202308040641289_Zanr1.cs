namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zanr1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "ZanrId_Id", "dbo.Zanrs");
            DropIndex("dbo.Films", new[] { "ZanrId_Id" });
            RenameColumn(table: "dbo.Films", name: "ZanrId_Id", newName: "ZanrId");
            AlterColumn("dbo.Films", "ZanrId", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "ZanrId");
            AddForeignKey("dbo.Films", "ZanrId", "dbo.Zanrs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "ZanrId", "dbo.Zanrs");
            DropIndex("dbo.Films", new[] { "ZanrId" });
            AlterColumn("dbo.Films", "ZanrId", c => c.Int());
            RenameColumn(table: "dbo.Films", name: "ZanrId", newName: "ZanrId_Id");
            CreateIndex("dbo.Films", "ZanrId_Id");
            AddForeignKey("dbo.Films", "ZanrId_Id", "dbo.Zanrs", "Id");
        }
    }
}
