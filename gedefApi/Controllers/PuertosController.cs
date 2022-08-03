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
    public class PuertosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public PuertosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Puertos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puertos>>> GetTBA_PUERTOS()
        {
          if (_context.TBA_PUERTOS == null)
          {
              return NotFound();
          }
            return await _context.TBA_PUERTOS.ToListAsync();
        }

        // GET: api/Puertos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puertos>> GetPuertos(int id)
        {
          if (_context.TBA_PUERTOS == null)
          {
              return NotFound();
          }
            var puertos = await _context.TBA_PUERTOS.FindAsync(id);

            if (puertos == null)
            {
                return NotFound();
            }

            return puertos;
        }

        // PUT: api/Puertos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuertos(int id, Puertos puertos)
        {
            if (id != puertos.CODPUE)
            {
                return BadRequest();
            }

            _context.Entry(puertos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertosExists(id))
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

        // POST: api/Puertos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puertos>> PostPuertos(Puertos puertos)
        {
          if (_context.TBA_PUERTOS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_PUERTOS'  is null.");
          }
            _context.TBA_PUERTOS.Add(puertos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuertos", new { id = puertos.CODPUE }, puertos);
        }

        // DELETE: api/Puertos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuertos(int id)
        {
            if (_context.TBA_PUERTOS == null)
            {
                return NotFound();
            }
            var puertos = await _context.TBA_PUERTOS.FindAsync(id);
            if (puertos == null)
            {
                return NotFound();
            }

            _context.TBA_PUERTOS.Remove(puertos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuertosExists(int id)
        {
            return (_context.TBA_PUERTOS?.Any(e => e.CODPUE == id)).GetValueOrDefault();
        }
    }
}
