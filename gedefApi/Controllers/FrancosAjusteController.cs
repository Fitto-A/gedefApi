using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.RRHH;
using Microsoft.AspNetCore.Http.HttpResults;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrancosAjusteController : ControllerBase
    {
        private readonly GedefDbContext _context;
        public FrancosAjusteController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/FrancosAjuste
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrancosAjuste>>> GetTBA_FRANCOS_AJUSTE()

        {
            if (_context.TBA_FRANCOS_AJUSTE == null)
            {
                return NotFound();
            }
            return await _context.TBA_FRANCOS_AJUSTE.ToListAsync();
        }

        // GET: api/FrancosAjuste/5
        [HttpGet("{idlegajo}")]
        public async Task<ActionResult<FrancosAjuste>> GetFrancosByIdLegajo(int idlegajo)

        {
            if (_context.TBA_FRANCOS_AJUSTE == null)
            {
                return NotFound();
            }
            var francos = await _context.TBA_FRANCOS_AJUSTE.ToListAsync();
            var francosByIdLegajo = francos.FindAll(e => e.IDLEGAJO ==  idlegajo);
           
            if (francosByIdLegajo == null)
            {
                return NotFound();
            }
            return Ok(francosByIdLegajo);
        }

        [HttpPost]
        public async Task<ActionResult<FrancosAjuste>> PostFrancosAjuste(FrancosAjuste francos)
        {

            if (_context.TBA_FRANCOS_AJUSTE == null)
            {
                return Problem("Entity set 'GedefDbContext.TBA_FRANCOS_AJUSTE'  is null.");
            }
            _context.TBA_FRANCOS_AJUSTE.Add(francos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTBA_FRANCOS_AJUSTE", francos);
        }

    }
}
