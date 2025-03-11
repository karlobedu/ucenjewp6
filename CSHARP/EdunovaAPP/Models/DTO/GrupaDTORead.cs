
namespace EdunovaAPP.Models.DTO
{
    /// <summary>
    /// DTO za čitanje podataka o grupi.
    /// </summary>
    /// <param name="Sifra">Jedinstveni identifikator grupe.</param>
    /// <param name="Naziv">Naziv grupe.</param>
    /// <param name="SmjerNaziv">Naziv smjera kojem grupa pripada.</param>
    /// <param name="Predavac">Ime predavača grupe.</param>
    /// <param name="MaksimalnoPolaznika">Maksimalan broj polaznika u grupi.</param>
    public record GrupaDTORead(
        int Sifra,
        string? Naziv,
        string? SmjerNaziv,
        string? Predavac,
        int? MaksimalnoPolaznika
        );


}