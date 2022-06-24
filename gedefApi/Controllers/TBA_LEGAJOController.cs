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
    public class TBA_LEGAJOController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public TBA_LEGAJOController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/TBA_LEGAJO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBA_LEGAJO>>> GetTBA_LEGAJOS()
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return NotFound();
          }
            return await _context.TBA_LEGAJOS.ToListAsync();
        }

        // GET: api/TBA_LEGAJO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TBA_LEGAJO>> GetTBA_LEGAJO(int id)
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return NotFound();
          }
            var tBA_LEGAJO = await _context.TBA_LEGAJOS.FindAsync(id);

            if (tBA_LEGAJO == null)
            {
                return NotFound();
            }

            return tBA_LEGAJO;
        }

        // PUT: api/TBA_LEGAJO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTBA_LEGAJO(int id, TBA_LEGAJO tBA_LEGAJO)
        {
            if (id != tBA_LEGAJO.IDLEG)
            {
                return BadRequest();
            }

            _context.Entry(tBA_LEGAJO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBA_LEGAJOExists(id))
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

        // POST: api/TBA_LEGAJO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TBA_LEGAJO>> PostTBA_LEGAJO(TBA_LEGAJO tBA_LEGAJO)
        {
          if (_context.TBA_LEGAJOS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_LEGAJOS'  is null.");
          }
            _context.TBA_LEGAJOS.Add(tBA_LEGAJO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTBA_LEGAJO", new { id = tBA_LEGAJO.IDLEG }, tBA_LEGAJO);
        }

        // DELETE: api/TBA_LEGAJO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTBA_LEGAJO(int id)
        {
            if (_context.TBA_LEGAJOS == null)
            {
                return NotFound();
            }
            var tBA_LEGAJO = await _context.TBA_LEGAJOS.FindAsync(id);
            if (tBA_LEGAJO == null)
            {
                return NotFound();
            }

            _context.TBA_LEGAJOS.Remove(tBA_LEGAJO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TBA_LEGAJOExists(int id)
        {
            return (_context.TBA_LEGAJOS?.Any(e => e.IDLEG == id)).GetValueOrDefault();
        }
    }
}
