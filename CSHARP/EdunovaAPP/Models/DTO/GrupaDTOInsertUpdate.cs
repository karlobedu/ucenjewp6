
using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za unos i ažuriranje grupe.
    /// </summary>
    /// <param name="Naziv">Naziv grupe (obavezno).</param>
    /// <param name="SmjerSifra">Šifra smjera (obavezno, mora biti između 1 i int.MaxValue).</param>
    /// <param name="Predavac">Ime predavača.</param>
    /// <param name="MaksimalnoPolaznika">Maksimalan broj polaznika (obavezno, mora biti između 5 i 30).</param>
    public record GrupaDTOInsertUpdate(
        [Required(ErrorMessage = "Naziv obavezno")]
            string? Naziv,
        [Range(1, int.MaxValue, ErrorMessage = "{0} mora biti između {1} i {2}")]
            [Required(ErrorMessage = "smjer obavezno")]
            int? SmjerSifra,
        string? Predavac,
        [Range(5, 30, ErrorMessage = "{0} mora biti između {1} i {2}")]
            [Required(ErrorMessage = "Najveći broj polaznika obavezno")]
            int MaksimalnoPolaznika
        );


}