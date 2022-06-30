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
    public class PlantillasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public PlantillasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Plantillas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plantillas>>> GetTBA_PLANTILLAS()
        {
            if (_context.TBA_PLANTILLAS == null)
            {
                return NotFound();
            }
            return await _context.TBA_PLANTILLAS.ToListAsync();
        }

        // GET: api/Plantillas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plantillas>> GetPlantillas(int id)
        {
            if (_context.TBA_PLANTILLAS == null)
            {
                return NotFound();
            }
            var plantillas = await _context.TBA_PLANTILLAS.FindAsync(id);

            if (plantillas == null)
            {
                return NotFound();
            }

            return plantillas;
        }

        // PUT: api/Plantillas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantillas(int id, Plantillas plantillas)
        {
            if (id != plantillas.CODPLA)
            {
                return BadRequest();
            }

            _context.Entry(plantillas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantillasExists(id))
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

        // POST: api/Plantillas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plantillas>> PostPlantillas(Plantillas plantillas)
        {
            if (_context.TBA_PLANTILLAS == null)
            {
                return Problem("Entity set 'GedefDbContext.TBA_PLANTILLAS'  is null.");
            }
            _context.TBA_PLANTILLAS.Add(plantillas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantillas", new { id = plantillas.CODPLA }, plantillas);
        }

        // DELETE: api/Plantillas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantillas(int id)
        {
            if (_context.TBA_PLANTILLAS == null)
            {
                return NotFound();
            }
            var plantillas = await _context.TBA_PLANTILLAS.FindAsync(id);
            if (plantillas == null)
            {
                return NotFound();
            }

            _context.TBA_PLANTILLAS.Remove(plantillas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantillasExists(int id)
        {
            return (_context.TBA_PLANTILLAS?.Any(e => e.CODPLA == id)).GetValueOrDefault();
        }
    }
}
