using AutoMapper;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Kontroler za upravljanje polaznicima.
    /// </summary>
    /// <param name="context">Kontekst baze podataka.</param>
    /// <param name="mapper">Mapper za mapiranje objekata.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PolaznikController(EdunovaContext context, IMapper mapper) : EdunovaController(context, mapper)
    {
        /// <summary>
        /// Dohvaća sve polaznike.
        /// </summary>
        /// <returns>Lista polaznika.</returns>
        [HttpGet]
        public ActionResult<List<PolaznikDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<PolaznikDTORead>>(_context.Polaznici));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća polaznika prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra polaznika.</param>
        /// <returns>Polaznik.</returns>
        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<PolaznikDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Polaznik? e;
            try
            {
                e = _context.Polaznici.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Polaznik ne postoji u bazi" });
            }

            return Ok(_mapper.Map<PolaznikDTOInsertUpdate>(e));
        }

        /// <summary>
        /// Dodaje novog polaznika.
        /// </summary>
        /// <param name="dto">Podaci o polazniku.</param>
        /// <returns>Status kreiranja.</returns>
        [HttpPost]
        public IActionResult Post(PolaznikDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Polaznik>(dto);
                _context.Polaznici.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<PolaznikDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Ažurira polaznika prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra polaznika.</param>
        /// <param name="dto">Podaci o polazniku.</param>
        /// <returns>Status ažuriranja.</returns>
        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, PolaznikDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Polaznik? e;
                try
                {
                    e = _context.Polaznici.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Polaznik ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Polaznici.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Briše polaznika prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra polaznika.</param>
        /// <returns>Status brisanja.</returns>
        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Polaznik? e;
                try
                {
                    e = _context.Polaznici.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Polaznik ne postoji u bazi");
                }
                _context.Polaznici.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Traži polaznike prema uvjetu.
        /// </summary>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Lista polaznika.</returns>
        [HttpGet]
        [Route("trazi/{uvjet}")]
        public ActionResult<List<PolaznikDTORead>> TraziPolaznik(string uvjet)
        {
            if (uvjet == null || uvjet.Length < 3)
            {
                return BadRequest(ModelState);
            }
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Polaznik> query = _context.Polaznici;
                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }
                var polaznici = query.ToList();
                return Ok(_mapper.Map<List<PolaznikDTORead>>(polaznici));
            }
            catch (Exception e)
            {
                return BadRequest(new { poruka = e.Message });
            }
        }

        /// <summary>
        /// Traži polaznike s paginacijom.
        /// </summary>
        /// <param name="stranica">Broj stranice.</param>
        /// <param name="uvjet">Uvjet pretrage.</param>
        /// <returns>Lista polaznika.</returns>
        [HttpGet]
        [Route("traziStranicenje/{stranica}")]
        public IActionResult TraziPolaznikStranicenje(int stranica, string uvjet = "")
        {
            var poStranici = 4;
            uvjet = uvjet.ToLower();
            try
            {
                IEnumerable<Polaznik> query = _context.Polaznici;

                var niz = uvjet.Split(" ");
                foreach (var s in uvjet.Split(" "))
                {
                    query = query.Where(p => p.Ime.ToLower().Contains(s) || p.Prezime.ToLower().Contains(s));
                }
                query
                    .OrderBy(p => p.Prezime);
                var polaznici = query.ToList();
                var filtriranaLista = polaznici.Skip((poStranici * stranica) - poStranici).Take(poStranici);
                return Ok(_mapper.Map<List<PolaznikDTORead>>(filtriranaLista.ToList())); // za potrebe testiranja
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Postavlja sliku za polaznika.
        /// </summary>
        /// <param name="sifra">Šifra polaznika.</param>
        /// <param name="slika">Podaci o slici.</param>
        /// <returns>Status postavljanja slike.</returns>
        [HttpPut]
        [Route("postaviSliku/{sifra:int}")]
        public IActionResult PostaviSliku(int sifra, SlikaDTO slika)
        {
            if (sifra <= 0)
            {
                return BadRequest("Šifra mora biti veća od nula (0)");
            }
            if (slika.Base64 == null || slika.Base64?.Length == 0)
            {
                return BadRequest("Slika nije postavljena");
            }
            var p = _context.Polaznici.Find(sifra);
            if (p == null)
            {
                return BadRequest("Ne postoji polaznik s šifrom " + sifra + ".");
            }
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "polaznici");

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                var putanja = Path.Combine(dir + ds + sifra + ".png");
                System.IO.File.WriteAllBytes(putanja, Convert.FromBase64String(slika.Base64!));
                return Ok("Uspješno pohranjena slika");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Generira polaznike.
        /// </summary>
        /// <param name="broj">Broj polaznika za generiranje.</param>
        /// <returns>Status generiranja.</returns>
        [HttpGet]
        [Route("Generiraj/{broj:int}")]
        public IActionResult Generiraj(int broj)
        {
            Polaznik p;
            for (int i = 0; i < broj; i++)
            {
                p = new Polaznik()
                {
                    Ime = Faker.Name.First(),
                    Prezime = Faker.Name.Last(),
                    Email = Faker.Internet.Email()
                };
                _context.Polaznici.Add(p);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
