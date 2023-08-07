namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipKupca : DbMigration
    {
        public override void Up()
        {


            Sql("SET IDENTITY_INSERT TipKupcas ON");
            Sql("INSERT INTO TipKupcas(Id, Naziv) VALUES (10, 'Test')");

            Sql("SET IDENTITY_INSERT TipKupcas OFF");

        }

        public override void Down()
        {
        }
    }
}
