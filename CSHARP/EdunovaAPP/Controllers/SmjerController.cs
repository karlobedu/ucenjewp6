﻿using AutoMapper;
using EdunovaAPP.Data;
using EdunovaAPP.Models;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Kontroler za upravljanje smjerovima u aplikaciji.
    /// </summary>
    /// <param name="context">Instanca EdunovaContext klase koja se koristi za pristup bazi podataka.</param>
    /// <param name="mapper">Instanca IMapper sučelja koja se koristi za mapiranje objekata.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SmjerController(EdunovaContext context, IMapper mapper) : EdunovaController(context, mapper)
    {
        /// <summary>
        /// Dohvaća sve smjerove.
        /// </summary>
        /// <returns>Lista DTO objekata smjerova.</returns>
        [HttpGet]
        public ActionResult<List<SmjerDTORead>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                return Ok(_mapper.Map<List<SmjerDTORead>>(_context.Smjerovi));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća smjer prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra smjera.</param>
        /// <returns>DTO objekt smjera.</returns>
        [HttpGet]
        [Route("{sifra:int}")]
        public ActionResult<SmjerDTOInsertUpdate> GetBySifra(int sifra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            Smjer? e;
            try
            {
                e = _context.Smjerovi.Find(sifra);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
            if (e == null)
            {
                return NotFound(new { poruka = "Smjer ne postoji u bazi" });
            }

            return Ok(_mapper.Map<SmjerDTOInsertUpdate>(e));
        }

        /// <summary>
        /// Dodaje novi smjer.
        /// </summary>
        /// <param name="dto">DTO objekt za unos ili ažuriranje smjera.</param>
        /// <returns>Status kreiranja i DTO objekt novog smjera.</returns>
        [HttpPost]
        public IActionResult Post(SmjerDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                var e = _mapper.Map<Smjer>(dto);
                _context.Smjerovi.Add(e);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<SmjerDTORead>(e));
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Ažurira postojeći smjer prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra smjera.</param>
        /// <param name="dto">DTO objekt za unos ili ažuriranje smjera.</param>
        /// <returns>Status ažuriranja.</returns>
        [HttpPut]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Put(int sifra, SmjerDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { poruka = ModelState });
            }
            try
            {
                Smjer? e;
                try
                {
                    e = _context.Smjerovi.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound(new { poruka = "Smjer ne postoji u bazi" });
                }

                e = _mapper.Map(dto, e);

                _context.Smjerovi.Update(e);
                _context.SaveChanges();

                return Ok(new { poruka = "Uspješno promjenjeno" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Briše smjer prema šifri.
        /// </summary>
        /// <param name="sifra">Šifra smjera.</param>
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
                Smjer? e;
                try
                {
                    e = _context.Smjerovi.Find(sifra);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { poruka = ex.Message });
                }
                if (e == null)
                {
                    return NotFound("Smjer ne postoji u bazi");
                }
                _context.Smjerovi.Remove(e);
                _context.SaveChanges();
                return Ok(new { poruka = "Uspješno obrisano" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}
