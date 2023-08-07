using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class TipKupca
    {
        public int Id { get; set; }
        [DisplayName("Naziv tipa kupca")]
        [MaxLength(50)]
        public string Naziv { get; set; }
    }
}