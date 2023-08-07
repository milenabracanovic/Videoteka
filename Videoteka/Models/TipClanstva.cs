using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class TipClanstva
    {
        public int Id { get; set; }
        public int Clanarina { get; set; }
        public int TrajanjeMjeseci { get; set; }
        public int ProcenatPopusta{ get; set; }
        [DisplayName("Naziv tipa clanstva")]
        public string Naziv { get; set; }
    }
}