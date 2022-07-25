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
    public class NumeradoresController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public NumeradoresController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Numeradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Numeradores>>> GetTBA_NUMERADORES()
        {
          if (_context.TBA_NUMERADORES == null)
          {
              return NotFound();
          }
            return await _context.TBA_NUMERADORES.ToListAsync();
        }

        // GET: api/Numeradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Numeradores>> GetNumeradores(int id)
        {
          if (_context.TBA_NUMERADORES == null)
          {
              return NotFound();
          }
            var numeradores = await _context.TBA_NUMERADORES.FindAsync(id);

            if (numeradores == null)
            {
                return NotFound();
            }

            return numeradores;
        }

        // PUT: api/Numeradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeradores(int id, Numeradores numeradores)
        {
            if (id != numeradores.IDNUM)
            {
                return BadRequest();
            }

            _context.Entry(numeradores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumeradoresExists(id))
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

        // POST: api/Numeradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Numeradores>> PostNumeradores(Numeradores numeradores)
        {
          if (_context.TBA_NUMERADORES == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_NUMERADORES'  is null.");
          }
            _context.TBA_NUMERADORES.Add(numeradores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNumeradores", new { id = numeradores.IDNUM }, numeradores);
        }

        // DELETE: api/Numeradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumeradores(int id)
        {
            if (_context.TBA_NUMERADORES == null)
            {
                return NotFound();
            }
            var numeradores = await _context.TBA_NUMERADORES.FindAsync(id);
            if (numeradores == null)
            {
                return NotFound();
            }

            _context.TBA_NUMERADORES.Remove(numeradores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NumeradoresExists(int id)
        {
            return (_context.TBA_NUMERADORES?.Any(e => e.IDNUM == id)).GetValueOrDefault();
        }
    }
}
