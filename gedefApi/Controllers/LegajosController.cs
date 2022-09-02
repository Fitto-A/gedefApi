using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegajosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public LegajosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Legajos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Legajos>>> GetTBA_LEGAJOS()
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return NotFound();
          }
            return await _context.TBA_LEGAJOS.ToListAsync();
        }

        // GET: api/Legajos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Legajos>> GetLegajos(int id)
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return NotFound();
          }
            var legajos = await _context.TBA_LEGAJOS.FindAsync(id);

            if (legajos == null)
            {
                return NotFound();
            }

            return legajos;
        }

        // PUT: api/Legajos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegajos(int id, Legajos legajos)
        {
            if (id != legajos.Id)
            {
                return BadRequest();
            }

            _context.Entry(legajos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegajosExists(id))
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

        // POST: api/Legajos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Legajos>> PostLegajos(Legajos legajos)
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_LEGAJOS'  is null.");
          }
            _context.TBA_LEGAJOS.Add(legajos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegajos", new { id = legajos.Id }, legajos);
        }

        // DELETE: api/Legajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegajos(int id)
        {
            if (_context.TBA_LEGAJOS == null)
            {
                return NotFound();
            }
            var legajos = await _context.TBA_LEGAJOS.FindAsync(id);
            if (legajos == null)
            {
                return NotFound();
            }

            _context.TBA_LEGAJOS.Remove(legajos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegajosExists(int id)
        {
            return (_context.TBA_LEGAJOS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
