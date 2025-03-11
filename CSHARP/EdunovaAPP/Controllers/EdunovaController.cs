using AutoMapper;
using EdunovaAPP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdunovaAPP.Controllers
{
    /// <summary>
    /// Apstraktna klasa EdunovaController koja služi kao osnovna klasa za sve kontrolere u aplikaciji.
    /// </summary>
    /// <param name="context">Instanca EdunovaContext klase koja se koristi za pristup bazi podataka.</param>
    /// <param name="mapper">Instanca IMapper sučelja koja se koristi za mapiranje objekata.</param>
    [Authorize]
    public abstract class EdunovaController(EdunovaContext context, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Kontekst baze podataka.
        /// </summary>
        protected readonly EdunovaContext _context = context;

        /// <summary>
        /// Mapper za mapiranje objekata.
        /// </summary>
        protected readonly IMapper _mapper = mapper;
    }
}
