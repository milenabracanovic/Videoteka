namespace VideotekaAPI.Models
{
    public class Pozajmica
    {
        public int Id { get; set; }
        public int KupacId { get; set; }
        public int FilmId { get; set; }
        public DateTime DatumPozajmice { get; set; }
        public DateTime DatumVracanja { get; set; }
        public string Napomena { get; set; }

        public Kupac Kupac { get; set; }
        public Film Film { get; set; }
    }
}
