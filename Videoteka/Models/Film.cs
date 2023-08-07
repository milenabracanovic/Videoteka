using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Film
    {
        public int Id { get; set; }
        [DisplayName("Naziv")]
        public string Naziv { get; set; }
        [DisplayName("Zanr")]
        public int ZanrId { get; set; }
        [DisplayName("Datum unosa")]
        public DateTime DatumUnosa { get; set; }
        [DisplayName("Datum izdanja")]
        public DateTime DatumIzdanja { get; set; }
        [DisplayName("Broj na stanju")]
        public int BrojNaStanju { get; set; }
        [DisplayName("Broj dostupnih")]
        public int BrojDostupnih { get; set; }

        public Zanr Zanr { get; set; }
    
    }
}