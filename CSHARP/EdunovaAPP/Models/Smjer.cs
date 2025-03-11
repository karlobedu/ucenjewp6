using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    /// <summary>
    /// Predstavlja smjer u sustavu.
    /// </summary>
    public class Smjer : Entitet
    {
        /// <summary>
        /// Naziv smjera.
        /// </summary>
        public string Naziv { get; set; } = "";

        /// <summary>
        /// Cijena smjera.
        /// </summary>
        public decimal? Cijena { get; set; }

        /// <summary>
        /// Datum od kada se smjer izvodi.
        /// </summary>
        public DateTime? IzvodiSeOd { get; set; }

        /// <summary>
        /// Označava da li smjer ima vaučer.
        /// </summary>
        public bool? Vaucer { get; set; }
    }
}
