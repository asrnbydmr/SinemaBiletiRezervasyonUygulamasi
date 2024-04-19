
namespace AsrınBaydemir.Models
{
    public partial class Film
    {
        public int id { get; set; }

        public string? FilmAd { get; set; }

        public DateTime FilmTarih { get; set; }

        public TimeSpan Saat1 { get; set; }

        public TimeSpan Saat2 { get; set; }

        public TimeSpan Saat3 { get; set; }

        public TimeSpan Saat4 { get; set; }

        public TimeSpan Saat5 { get; set; }

        public TimeSpan Saat6 { get; set; }
    }
}
