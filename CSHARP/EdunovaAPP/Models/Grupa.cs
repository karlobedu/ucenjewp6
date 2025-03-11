using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    /// <summary>
    /// Klasa koja predstavlja grupu.
    /// </summary>
    public class Grupa : Entitet
    {
        /// <summary>
        /// Naziv grupe.
        /// </summary>
        public string Naziv { get; set; } = "";

        /// <summary>
        /// Smjer kojem grupa pripada.
        /// </summary>
        [ForeignKey("smjer")]
        public required Smjer Smjer { get; set; }

        /// <summary>
        /// Predavač grupe.
        /// </summary>
        public string? Predavac { get; set; }

        /// <summary>
        /// Maksimalan broj polaznika u grupi.
        /// </summary>
        [Column("velicinagrupe")]
        public int MaksimalnoPolaznika { get; set; }

        /// <summary>
        /// Polaznici koji su upisani u grupu.
        /// </summary>
        public ICollection<Polaznik>? Polaznici { get; set; }
    }
}