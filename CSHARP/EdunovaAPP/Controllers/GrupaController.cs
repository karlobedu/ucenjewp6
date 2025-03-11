﻿using AutoMapper;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Kontroler za upravljanje grupama u aplikaciji.
    /// </summary>
    /// <param name="context">Instanca EdunovaContext klase koja se koristi za pristup bazi podataka.</param>
    /// <param name="mapper">Instanca IMapper sučelja koja se koristi za mapiranje objekata.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GrupaController(EdunovaContext context, IMapper mapper) : EdunovaController(context, mapper)
    {
        /// <summary>
        /// Dohvaća sve grupe.
        /// </summary>
        /// <returns>Lista grupa.</returns>
        [HttpGet]
        public ActionResult<List<GrupaDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<GrupaDTORead>>(_context.Grupe.Include(g => g.Smjer)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća grupu prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra grupe.</param>
        /// <returns>Grupa sa zadanom šifrom.</returns>
        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<GrupaDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Grupa? e;
            try
            {
                e = _context.Grupe.Include(g => g.Smjer).FirstOrDefault(g => g.Sifra == sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Grupa ne postoji u bazi" });
            }

            return Ok(_mapper.Map<GrupaDTOInsertUpdate>(e));
        }

        /// <summary>
        /// Dodaje novu grupu.
        /// </summary>
        /// <param name="dto">Podaci o grupi.</param>
        /// <returns>Status kreiranja.</returns>
        [HttpPost]
        public IActionResult Post(GrupaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }

            Smjer? es;
            try
            {
                es = _context.Smjerovi.Find(dto.SmjerSifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (es == null)
            {
                return NotFound(new { poruka = "Smjer na grupi ne postoji u bazi" });
            }

            try
            {
                var e = _mapper.Map<Grupa>(dto);
                e.Smjer = es;
                _context.Grupe.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<GrupaDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Ažurira postojeću grupu.
        /// </summary>
        /// <param name="sifra">Šifra grupe.</param>
        /// <param name="dto">Podaci o grupi.</param>
        /// <returns>Status ažuriranja.</returns>
        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, GrupaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Grupa? e;
                try
                {
                    e = _context.Grupe.Include(g => g.Smjer).FirstOrDefault(x => x.Sifra == sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Grupa ne postoji u bazi" });
                }

                Smjer? es;
                try
                {
                    es = _context.Smjerovi.Find(dto.SmjerSifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (es == null)
                {
                    return NotFound(new { poruka = "Smjer na grupi ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);
                e.Smjer = es;
                _context.Grupe.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Briše grupu prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra grupe.</param>
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
                Grupa? e;
                try
                {
                    e = _context.Grupe.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Grupa ne postoji u bazi");
                }
                _context.Grupe.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća polaznike grupe prema šifri grupe.
        /// </summary>
        /// <param name="sifraGrupe">Šifra grupe.</param>
        /// <returns>Lista polaznika grupe.</returns>
        [HttpGet]
        [Route("Polaznici/{sifraGrupe:int}")]
        public ActionResult<List<PolaznikDTORead>> GetPolaznici(int sifraGrupe)
        {
            if (!ModelState.IsValid || sifraGrupe <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Grupe
                    .Include(i => i.Polaznici).FirstOrDefault(x => x.Sifra == sifraGrupe);
                if (p == null)
                {
                    return BadRequest("Ne postoji grupa s šifrom " + sifraGrupe + " u bazi");
                }

                return Ok(_mapper.Map<List<PolaznikDTORead>>(p.Polaznici));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dodaje polaznika u grupu.
        /// </summary>
        /// <param name="sifra">Šifra grupe.</param>
        /// <param name="polaznikSifra">Šifra polaznika.</param>
        /// <returns>Status dodavanja.</returns>
        [HttpPost]
        [Route("{sifra:int}/dodaj/{polaznikSifra:int}")]
        public IActionResult DodajPolaznika(int sifra, int polaznikSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 || polaznikSifra <= 0)
            {
                return BadRequest("Šifra grupe ili polaznika nije dobra");
            }
            try
            {
                var grupa = _context.Grupe
                    .Include(g => g.Polaznici)
                    .FirstOrDefault(g => g.Sifra == sifra);
                if (grupa == null)
                {
                    return BadRequest("Ne postoji grupa s šifrom " + sifra + " u bazi");
                }
                var polaznik = _context.Polaznici.Find(polaznikSifra);
                if (polaznik == null)
                {
                    return BadRequest("Ne postoji polaznik s šifrom " + polaznikSifra + " u bazi");
                }
                grupa.Polaznici?.Add(polaznik);
                _context.Grupe.Update(grupa);
                _context.SaveChanges();
                return Ok(new
                {
                    poruka = "Polaznik " + polaznik.Prezime + " " + polaznik.Ime + " dodan na grupu "
                 + grupa.Naziv
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                       StatusCodes.Status503ServiceUnavailable,
                       ex.Message);
            }
        }

        /// <summary>
        /// Briše polaznika iz grupe.
        /// </summary>
        /// <param name="sifra">Šifra grupe.</param>
        /// <param name="polaznikSifra">Šifra polaznika.</param>
        /// <returns>Status brisanja.</returns>
        [HttpDelete]
        [Route("{sifra:int}/obrisi/{polaznikSifra:int}")]
        public IActionResult ObrisiPolaznika(int sifra, int polaznikSifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sifra <= 0 || polaznikSifra <= 0)
            {
                return BadRequest("Šifra grupe ili polaznika nije dobra");
            }
            try
            {
                var grupa = _context.Grupe
                    .Include(g => g.Polaznici)
                    .FirstOrDefault(g => g.Sifra == sifra);
                if (grupa == null)
                {
                    return BadRequest("Ne postoji grupa s šifrom " + sifra + " u bazi");
                }
                var polaznik = _context.Polaznici.Find(polaznikSifra);
                if (polaznik == null)
                {
                    return BadRequest("Ne postoji polaznik s šifrom " + polaznikSifra + " u bazi");
                }
                grupa.Polaznici?.Remove(polaznik);
                _context.Grupe.Update(grupa);
                _context.SaveChanges();

                return Ok(new
                {
                    poruka = "Polaznik " + polaznik.Prezime + " " + polaznik.Ime + " obrisan iz grupe "
                 + grupa.Naziv
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća graf grupe.
        /// </summary>
        /// <returns>Lista grafova grupa.</returns>
        [HttpGet]
        [Route("GrafGrupe")]
        public ActionResult<List<GrafGrupaDTO>> GrafGrupe()
        {
            try
            {
                return Ok(_mapper.Map<List<GrafGrupaDTO>>(_context.Grupe.Include(g => g.Polaznici)));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}