namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zanrDodaj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipKupcas", "Naziv", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipKupcas", "Naziv", c => c.String());
        }
    }
}
