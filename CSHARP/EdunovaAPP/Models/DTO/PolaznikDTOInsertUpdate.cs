
using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za unos i ažuriranje polaznika.
    /// </summary>
    /// <param name="Ime">Ime polaznika. Obavezno polje.</param>
    /// <param name="Prezime">Prezime polaznika. Obavezno polje.</param>
    /// <param name="Email">Email polaznika. Obavezno polje. Mora biti u ispravnom formatu.</param>
    /// <param name="Oib">OIB polaznika.</param>
    public record PolaznikDTOInsertUpdate(
        [Required(ErrorMessage = "Ime obavezno")]
            string? Ime,
        [Required(ErrorMessage = "Prezime obavezno")]
            string? Prezime,
        [Required(ErrorMessage = "Email obavezno")]
            [EmailAddress(ErrorMessage ="Email nije dobrog formata")]
            string? Email,
        string? Oib);
}
