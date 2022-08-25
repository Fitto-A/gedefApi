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
    public class ParteSinPescasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public ParteSinPescasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/ParteSinPescas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParteSinPesca>>> GetTBA_PARTESINPESCA()
        {
          if (_context.TBA_PARTESINPESCA == null)
          {
              return NotFound();
          }
            return await _context.TBA_PARTESINPESCA.ToListAsync();
        }

        // GET: api/ParteSinPescas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParteSinPesca>> GetParteSinPesca(int id)
        {
          if (_context.TBA_PARTESINPESCA == null)
          {
              return NotFound();
          }
            var parteSinPesca = await _context.TBA_PARTESINPESCA.FindAsync(id);

            if (parteSinPesca == null)
            {
                return NotFound();
            }

            return parteSinPesca;
        }

        // PUT: api/ParteSinPescas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParteSinPesca(int id, ParteSinPesca parteSinPesca)
        {
            if (id != parteSinPesca.IDPSP)
            {
                return BadRequest();
            }

            _context.Entry(parteSinPesca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteSinPescaExists(id))
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

        // POST: api/ParteSinPescas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParteSinPesca>> PostParteSinPesca(ParteSinPesca parteSinPesca)
        {
          if (_context.TBA_PARTESINPESCA == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_PARTESINPESCA'  is null.");
          }
            _context.TBA_PARTESINPESCA.Add(parteSinPesca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParteSinPesca", new { id = parteSinPesca.IDPSP }, parteSinPesca);
        }

        // DELETE: api/ParteSinPescas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParteSinPesca(int id)
        {
            if (_context.TBA_PARTESINPESCA == null)
            {
                return NotFound();
            }
            var parteSinPesca = await _context.TBA_PARTESINPESCA.FindAsync(id);
            if (parteSinPesca == null)
            {
                return NotFound();
            }

            _context.TBA_PARTESINPESCA.Remove(parteSinPesca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParteSinPescaExists(int id)
        {
            return (_context.TBA_PARTESINPESCA?.Any(e => e.IDPSP == id)).GetValueOrDefault();
        }
    }
}
