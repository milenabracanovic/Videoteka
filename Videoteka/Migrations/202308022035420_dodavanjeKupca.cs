namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodavanjeKupca : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Kupacs ON");

            Sql("INSERT INTO Kupacs(Id, Ime, PrimaObavjestenja, DatumRodjenja, TipClanstvaId_Id, TipKupcaId_Id) VALUES (1, 'Milena', 1, '10.01.1999', 1, 1)");
            Sql("INSERT INTO Kupacs(Id, Ime, PrimaObavjestenja, DatumRodjenja, TipClanstvaId_Id, TipKupcaId_Id) VALUES (2, 'Nina', 1, '15.04.1997', 1, 1)");

        
        }
        
        public override void Down()
        {
        }
    }
}
