namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoviClanova : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT TipClanstvas ON");

            Sql("INSERT INTO TipClanstvas(Id, Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (1, 0, 0, 0, 'Po vidjenju')");
            Sql("INSERT INTO TipClanstvas(Id, Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (2, 30, 1, 10, 'Mjesecno')");
            Sql("INSERT INTO TipClanstvas(Id, Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (3, 90, 3, 15, 'Kvartalno')");
            Sql("INSERT INTO TipClanstvas(Id, Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (4, 165, 6, 20, 'Polugodisnje')");
            Sql("INSERT INTO TipClanstvas(Id, Clanarina, TrajanjeMjeseci, ProcenatPopusta, Naziv) VALUES (5, 300, 12, 30, 'Godisnje')");

            Sql("SET IDENTITY_INSERT TipClanstvas OFF");
        }
    }
        
      
    }

