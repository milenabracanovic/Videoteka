using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Zanr
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Zanr")]
        public string Naziv { get; set; }
    }
}