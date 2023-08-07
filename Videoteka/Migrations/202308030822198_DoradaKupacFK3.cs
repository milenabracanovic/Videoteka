namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoradaKupacFK3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kupacs", "DatumRodjenja", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kupacs", "DatumRodjenja", c => c.String());
        }
    }
}
