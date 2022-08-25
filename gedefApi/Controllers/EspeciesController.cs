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
    public class EspeciesController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public EspeciesController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Especies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especies>>> GetTBA_ESPECIES()
        {
          if (_context.TBA_ESPECIES == null)
          {
              return NotFound();
          }
            return await _context.TBA_ESPECIES.ToListAsync();
        }

        // GET: api/Especies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especies>> GetEspecies(int id)
        {
          if (_context.TBA_ESPECIES == null)
          {
              return NotFound();
          }
            var especies = await _context.TBA_ESPECIES.FindAsync(id);

            if (especies == null)
            {
                return NotFound();
            }

            return especies;
        }

        // PUT: api/Especies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecies(int id, Especies especies)
        {
            if (id != especies.IDESP)
            {
                return BadRequest();
            }

            _context.Entry(especies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspeciesExists(id))
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

        // POST: api/Especies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especies>> PostEspecies(Especies especies)
        {
          if (_context.TBA_ESPECIES == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_ESPECIES'  is null.");
          }
            _context.TBA_ESPECIES.Add(especies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecies", new { id = especies.IDESP }, especies);
        }

        // DELETE: api/Especies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecies(int id)
        {
            if (_context.TBA_ESPECIES == null)
            {
                return NotFound();
            }
            var especies = await _context.TBA_ESPECIES.FindAsync(id);
            if (especies == null)
            {
                return NotFound();
            }

            _context.TBA_ESPECIES.Remove(especies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspeciesExists(int id)
        {
            return (_context.TBA_ESPECIES?.Any(e => e.IDESP == id)).GetValueOrDefault();
        }
    }
}
