using EdunovaAPP.Data;
using EdunovaAPP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Kontroler za početne operacije.
    /// </summary>
    /// <param name="_context">Kontekst baze podataka.</param>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PocetnaController(EdunovaContext _context) : ControllerBase
    {
        /// <summary>
        /// Dohvaća dostupne smjerove.
        /// </summary>
        /// <returns>Lista dostupnih smjerova.</returns>
        [HttpGet]
        [Route("DostupniSmjerovi")]
        public ActionResult<List<SmjerDTORead>> DostupniSmjerovi()
        {
            try
            {
                var smjerovi = _context.Smjerovi.ToList();
                var lista = new List<object>();
                foreach (var smjer in smjerovi)
                {
                    lista.Add(new { smjer.Naziv });
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }

        /// <summary>
        /// Dohvaća ukupan broj polaznika.
        /// </summary>
        /// <returns>Ukupan broj polaznika.</returns>
        [HttpGet]
        [Route("UkupnoPolaznika")]
        public IActionResult UkupnoPolaznika()
        {
            try
            {
                return Ok(new { poruka = _context.Polaznici.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(new { poruka = ex.Message });
            }
        }
    }
}