using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.PartesPesca;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParteFinalsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public ParteFinalsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/ParteFinals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParteFinal>>> GetTBA_PARTEFINAL()
        {
          if (_context.TBA_PARTEFINAL == null)
          {
              return NotFound();
          }
            return await _context.TBA_PARTEFINAL.ToListAsync();
        }

        // GET: api/ParteFinals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParteFinal>> GetParteFinal(int id)
        {
          if (_context.TBA_PARTEFINAL == null)
          {
              return NotFound();
          }
            var parteFinal = await _context.TBA_PARTEFINAL.FindAsync(id);

            if (parteFinal == null)
            {
                return NotFound();
            }

            return parteFinal;
        }

        // PUT: api/ParteFinals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParteFinal(int id, ParteFinal parteFinal)
        {
            if (id != parteFinal.IDPFP)
            {
                return BadRequest();
            }

            _context.Entry(parteFinal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteFinalExists(id))
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

        // POST: api/ParteFinals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParteFinal>> PostParteFinal(ParteFinal parteFinal)
        {
          if (_context.TBA_PARTEFINAL == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_PARTEFINAL'  is null.");
          }
            _context.TBA_PARTEFINAL.Add(parteFinal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParteFinal", new { id = parteFinal.IDPFP }, parteFinal);
        }

        // DELETE: api/ParteFinals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParteFinal(int id)
        {
            if (_context.TBA_PARTEFINAL == null)
            {
                return NotFound();
            }
            var parteFinal = await _context.TBA_PARTEFINAL.FindAsync(id);
            if (parteFinal == null)
            {
                return NotFound();
            }

            _context.TBA_PARTEFINAL.Remove(parteFinal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParteFinalExists(int id)
        {
            return (_context.TBA_PARTEFINAL?.Any(e => e.IDPFP == id)).GetValueOrDefault();
        }
    }
}
