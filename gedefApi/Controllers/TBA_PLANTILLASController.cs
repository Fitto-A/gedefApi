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
    public class TBA_PLANTILLASController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public TBA_PLANTILLASController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/TBA_PLANTILLAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBA_PLANTILLAS>>> GetTBA_PLANTILLAS()
        {
          if (_context.TBA_PLANTILLAS == null)
          {
              return NotFound();
          }
            return await _context.TBA_PLANTILLAS.ToListAsync();
        }

        // GET: api/TBA_PLANTILLAS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TBA_PLANTILLAS>> GetTBA_PLANTILLAS(int id)
        {
          if (_context.TBA_PLANTILLAS == null)
          {
              return NotFound();
          }
            var tBA_PLANTILLAS = await _context.TBA_PLANTILLAS.FindAsync(id);

            if (tBA_PLANTILLAS == null)
            {
                return NotFound();
            }

            return tBA_PLANTILLAS;
        }

        // PUT: api/TBA_PLANTILLAS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTBA_PLANTILLAS(int id, TBA_PLANTILLAS tBA_PLANTILLAS)
        {
            if (id != tBA_PLANTILLAS.IDPLA)
            {
                return BadRequest();
            }

            _context.Entry(tBA_PLANTILLAS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBA_PLANTILLASExists(id))
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

        // POST: api/TBA_PLANTILLAS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TBA_PLANTILLAS>> PostTBA_PLANTILLAS(TBA_PLANTILLAS tBA_PLANTILLAS)
        {
          if (_context.TBA_PLANTILLAS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_PLANTILLAS'  is null.");
          }
            _context.TBA_PLANTILLAS.Add(tBA_PLANTILLAS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTBA_PLANTILLAS", new { id = tBA_PLANTILLAS.IDPLA }, tBA_PLANTILLAS);
        }

        // DELETE: api/TBA_PLANTILLAS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTBA_PLANTILLAS(int id)
        {
            if (_context.TBA_PLANTILLAS == null)
            {
                return NotFound();
            }
            var tBA_PLANTILLAS = await _context.TBA_PLANTILLAS.FindAsync(id);
            if (tBA_PLANTILLAS == null)
            {
                return NotFound();
            }

            _context.TBA_PLANTILLAS.Remove(tBA_PLANTILLAS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TBA_PLANTILLASExists(int id)
        {
            return (_context.TBA_PLANTILLAS?.Any(e => e.IDPLA == id)).GetValueOrDefault();
        }
    }
}
