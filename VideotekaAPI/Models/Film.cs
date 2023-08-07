﻿

namespace VideotekaAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int ZanrId { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojNaStanju { get; set; }
        public int BrojDostupnih { get; set; }

        public Zanr Zanr { get; set; }
    
    }
}