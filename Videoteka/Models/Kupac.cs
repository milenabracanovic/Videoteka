using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        [DisplayName("Prima obavjestenja")]
        public Boolean PrimaObavjestenja { get; set; }
        [DisplayName("Datum rodjenja")]
        public DateTime DatumRodjenja { get; set; }
        [DisplayName("Tip kupca")]
        public int TipKupcaId { get; set; }
        [DisplayName("Tip clanstva")]
        public int TipClanstvaId { get; set; }
        [DisplayName("Tip clanstva")]
        public TipClanstva TipClanstva { get; set; }
     
        [DisplayName("Tip kupca")]
        public TipKupca TipKupca { get; set; }


    }
}