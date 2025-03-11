using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za unos i ažuriranje smjera.
    /// </summary>
    /// <param name="Naziv">Naziv smjera (obavezno)</param>
    /// <param name="Cijena">Cijena smjera (mora biti između 0 i 10000)</param>
    /// <param name="IzvodiSeOd">Datum od kada se smjer izvodi</param>
    /// <param name="Vaucer">Indikator da li smjer ima vaučer</param>
    public record SmjerDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
            string Naziv,
        [Range(0, 10000, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
            decimal? Cijena,
        DateTime? IzvodiSeOd,
        bool? Vaucer
        );
}
