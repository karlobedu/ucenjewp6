
namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za čitanje podataka o smjeru.
    /// </summary>
    /// <param name="Sifra">Jedinstvena šifra smjera.</param>
    /// <param name="Naziv">Naziv smjera.</param>
    /// <param name="Cijena">Cijena smjera.</param>
    /// <param name="IzvodiSeOd">Datum od kada se smjer izvodi.</param>
    /// <param name="Vaucer">Indikator da li smjer uključuje vaučer.</param>
    public record SmjerDTORead(
        int Sifra,
        string Naziv,
        decimal? Cijena,
        DateTime? IzvodiSeOd,
        bool? Vaucer
        );

   
}
