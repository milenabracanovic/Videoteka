using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Pozajmica
    {
        public int Id { get; set; }
        [DisplayName("Kupac")]
        public int KupacId { get; set; }
        [DisplayName("Film")]
        public int FilmId { get; set; }
        [DisplayName("Datum pozajmice")]
        public DateTime DatumPozajmice { get; set; }
        [DisplayName("Datum vracanja")]
        public DateTime DatumVracanja { get; set; }
        [DisplayName("Napomena")]
        public string Napomena { get; set; }
       
        public Kupac Kupac { get; set; }
     
        public Film Film { get; set; }
    }
}