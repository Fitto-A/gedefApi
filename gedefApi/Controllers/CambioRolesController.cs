using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.RRHH;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambioRolesController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public CambioRolesController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/CambioRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CambioRoles>>> GetTBA_CAMBIOROLES()
        {
          if (_context.TBA_CAMBIOROLES == null)
          {
              return NotFound();
          }
            return await _context.TBA_CAMBIOROLES.ToListAsync();
        }

        // GET: api/CambioRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CambioRoles>> GetCambioRoles(int id)
        {
          if (_context.TBA_CAMBIOROLES == null)
          {
              return NotFound();
          }
            var cambioRoles = await _context.TBA_CAMBIOROLES.FindAsync(id);

            if (cambioRoles == null)
            {
                return NotFound();
            }

            return cambioRoles;
        }

        [HttpGet("byIdMarea/{idMar}")]
        public async Task<ActionResult<CambioRoles>> GetByIdMarea(int idMar)
        {
            if (_context.TBA_CAMBIOROLES == null)
            {
                return NotFound();
            }
            var cambioRoles = await _context.TBA_CAMBIOROLES.ToListAsync();
            var item = cambioRoles.FindAll(e => e.IDMAR == idMar);
            if (cambioRoles == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT: api/CambioRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCambioRoles(int id, CambioRoles cambioRoles)
        {
            if (id != cambioRoles.ID)
            {
                return BadRequest();
            }

            _context.Entry(cambioRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CambioRolesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CambioRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CambioRoles>> PostCambioRoles(CambioRoles cambioRoles)
        {
          if (_context.TBA_CAMBIOROLES == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_CAMBIOROLES'  is null.");
          }
            _context.TBA_CAMBIOROLES.Add(cambioRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCambioRoles", new { id = cambioRoles.ID }, cambioRoles);
        }

        // DELETE: api/CambioRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCambioRoles(int id)
        {
            if (_context.TBA_CAMBIOROLES == null)
            {
                return NotFound();
            }
            var cambioRoles = await _context.TBA_CAMBIOROLES.FindAsync(id);
            if (cambioRoles == null)
            {
                return NotFound();
            }

            _context.TBA_CAMBIOROLES.Remove(cambioRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CambioRolesExists(int id)
        {
            return (_context.TBA_CAMBIOROLES?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
