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
    public class LegajoController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public LegajoController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Legajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Legajo>>> GetLegajos()
        {
            if (_context.Legajos == null)
            {
                return NotFound();
            }
            return await _context.Legajos.ToListAsync();
        }

        // GET: api/Legajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Legajo>> GetLegajo(int id)
        {
            if (_context.Legajos == null)
            {
                return NotFound();
            }
            var legajo = await _context.Legajos.FindAsync(id);

            if (legajo == null)
            {
                return NotFound();
            }

            return legajo;
        }

        // PUT: api/Legajo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegajo(int id, Legajo legajo)
        {
            if (id != legajo.LegajoId)
            {
                return BadRequest();
            }

            _context.Entry(legajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegajoExists(id))
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

        // POST: api/Legajo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Legajo>> PostLegajo(Legajo legajo)
        {
            var temp = _context.Legajos
                .Where(x => x.Name == legajo.Name && x.email == legajo.email)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.Legajos.Add(legajo);
                await _context.SaveChangesAsync();
            }
            else
                legajo = temp;

            return Ok(legajo);
        }

        // DELETE: api/Legajo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegajo(int id)
        {
            if (_context.Legajos == null)
            {
                return NotFound();
            }
            var legajo = await _context.Legajos.FindAsync(id);
            if (legajo == null)
            {
                return NotFound();
            }

            _context.Legajos.Remove(legajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegajoExists(int id)
        {
            return (_context.Legajos?.Any(e => e.LegajoId == id)).GetValueOrDefault();
        }
    }
}
