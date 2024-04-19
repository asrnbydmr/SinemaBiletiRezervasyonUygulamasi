
namespace AsrınBaydemir.Models
{
    public partial class Seans
    {
        public int id { get; set; }

        public string? FilmAd { get; set; }

        public DateTime FilmTarih { get; set; }

        public TimeSpan FilmSaat {  get; set; }

        public string? FilmSalon { get; set; }

        public string? MusteriAd { get; set; }

        public string? TCKimlikNo { get; set; }
    }
}
