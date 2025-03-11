namespace EdunovaAPP.Models
{
    /// <summary>
    /// Klasa koja predstavlja polaznika.
    /// </summary>
    public class Polaznik : Entitet
    {
        /// <summary>
        /// Ime polaznika.
        /// </summary>
        public string Ime { get; set; } = "";

        /// <summary>
        /// Prezime polaznika.
        /// </summary>
        public string Prezime { get; set; } = "";

        /// <summary>
        /// OIB polaznika.
        /// </summary>
        public string? Oib { get; set; }

        /// <summary>
        /// Email polaznika.
        /// </summary>
        public string Email { get; set; } = "";

        /// <summary>
        /// Grupe u koje je polaznik upisan.
        /// </summary>
        public ICollection<Grupa>? Grupe { get; } = new List<Grupa>();
    }
}
