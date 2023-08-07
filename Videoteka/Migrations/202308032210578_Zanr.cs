namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zanr : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Zanrs ON");
            Sql("INSERT INTO Zanrs(Id, Naziv) VALUES (1, 'Horor')");
        }
        
        public override void Down()
        {
        }
    }
}
