using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using EmailService;
using Microsoft.Data.SqlClient;
using System.Data;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MareasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public MareasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Mareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREAS()
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            return await _context.TBA_MAREAS.ToListAsync();
        }

        [HttpGet("activasYConfeccion")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASActivasyConfeccion()
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var item = mareas.FindAll(e => e.ESTADO == "ACTIVA" || e.ESTADO == "CONFECCION");
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("getLastNumMarea/{id}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetLasNumMarea(int id)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var mareasFiltered = mareas.FindAll(m => m.CODBAR == id & m.ESTADO != "ELIMINADA");
            if (mareasFiltered == null) {
                return Ok(0);
            } else 
            {
                var item = mareasFiltered.Max(i => i.NUMMAREA);
                return Ok(item);
            }
           
        }

        // GET: api/Mareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mareas>> GetMareas(int id)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.FindAsync(id);

            if (mareas == null)
            {
                return NotFound();
            }

            return mareas;
        }

        // PUT: api/Mareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMareas(int id, Mareas mareas)
        {
            if (id != mareas.IDMAR)
            {
                return BadRequest();
            }

            _context.Entry(mareas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MareasExists(id))
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

        // POST: api/Mareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mareas>> PostMareas(Mareas mareas)
        {
            if (_context.TBA_MAREAS == null)
            {
                return Problem("Entity set 'GedefDbContext.TBA_MAREAS'  is null.");
            }
            _context.TBA_MAREAS.Add(mareas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMareas", new { id = mareas.IDMAR }, mareas);
        }

        // DELETE: api/Mareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMareas(int id)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.FindAsync(id);
            if (mareas == null)
            {
                return NotFound();
            }

            _context.TBA_MAREAS.Remove(mareas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MareasExists(int id)
        {
            return (_context.TBA_MAREAS?.Any(e => e.IDMAR == id)).GetValueOrDefault();
        }
    }
}
