
namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za čitanje podataka o polazniku.
    /// </summary>
    /// <param name="Sifra">Jedinstveni identifikator polaznika.</param>
    /// <param name="Ime">Ime polaznika.</param>
    /// <param name="Prezime">Prezime polaznika.</param>
    /// <param name="Email">Email adresa polaznika.</param>
    /// <param name="Oib">OIB polaznika (opcionalno).</param>
    /// <param name="Slika">URL slike polaznika (opcionalno).</param>
    public record PolaznikDTORead(
        int? Sifra,
        string Ime,
        string Prezime,
        string Email,
        string? Oib,
        string? Slika);


}
