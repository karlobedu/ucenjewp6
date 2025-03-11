using AutoMapper;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;

namespace EdunovaAPP.Mapping
{
    /// <summary>
    /// Klasa za definiranje mapiranja između modela i DTO objekata.
    /// </summary>
    public class EdunovaMappingProfile : Profile
    {
        /// <summary>
        /// Konstruktor u kojem se definiraju mapiranja.
        /// </summary>
        public EdunovaMappingProfile()
        {
            // kreiramo mapiranja: izvor, odredište
            CreateMap<Smjer, SmjerDTORead>();
            CreateMap<SmjerDTOInsertUpdate, Smjer>();
            CreateMap<Smjer, SmjerDTOInsertUpdate>();

            CreateMap<Polaznik, PolaznikDTORead>()
              .ConstructUsing(entitet =>
               new PolaznikDTORead(
                  entitet.Sifra,
                  entitet.Ime ?? "",
                  entitet.Prezime ?? "",
                  entitet.Email ?? "",
                  entitet.Oib,
                  PutanjaDatoteke(entitet)));
            CreateMap<PolaznikDTOInsertUpdate, Polaznik>();
            CreateMap<Polaznik, PolaznikDTOInsertUpdate>();

            CreateMap<Grupa, GrupaDTORead>()
               .ForCtorParam(
                   "SmjerNaziv",
                   opt => opt.MapFrom(src => src.Smjer.Naziv)
               );
            CreateMap<Grupa, GrupaDTOInsertUpdate>().ForMember(
                    dest => dest.SmjerSifra,
                    opt => opt.MapFrom(src => src.Smjer.Sifra)
                );
            CreateMap<GrupaDTOInsertUpdate, Grupa>();

            CreateMap<Grupa, GrafGrupaDTO>()
             .ConstructUsing(entitet =>
              new GrafGrupaDTO(
                 entitet.Naziv ?? "",
                 entitet.Polaznici == null ? 0 : entitet.Polaznici.Count()));
        }

        /// <summary>
        /// Metoda za dobivanje putanje do slike polaznika.
        /// </summary>
        /// <param name="e">Objekt polaznika.</param>
        /// <returns>Putanja do slike ili null ako slika ne postoji.</returns>
        private static string? PutanjaDatoteke(Polaznik e)
        {
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string slika = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "polaznici" + ds + e.Sifra + ".png");
                return File.Exists(slika) ? "/slike/polaznici/" + e.Sifra + ".png" : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
