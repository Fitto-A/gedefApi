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
    public class MotivosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public MotivosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Motivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivos>>> GetTBA_MOTIVOS()
        {
            return await _context.TBA_MOTIVOS.ToListAsync();
        }

        // GET: api/Motivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motivos>> GetMotivos(int id)
        {
            var motivos = await _context.TBA_MOTIVOS.FindAsync(id);

            if (motivos == null)
            {
                return NotFound();
            }

            return motivos;
        }

        // PUT: api/Motivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivos(int id, Motivos motivos)
        {
            if (id != motivos.IDPP)
            {
                return BadRequest();
            }

            _context.Entry(motivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivosExists(id))
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

        // POST: api/Motivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motivos>> PostMotivos(Motivos motivos)
        {
            _context.TBA_MOTIVOS.Add(motivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivos", new { id = motivos.IDPP }, motivos);
        }

        // DELETE: api/Motivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivos(int id)
        {
            var motivos = await _context.TBA_MOTIVOS.FindAsync(id);
            if (motivos == null)
            {
                return NotFound();
            }

            _context.TBA_MOTIVOS.Remove(motivos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivosExists(int id)
        {
            return _context.TBA_MOTIVOS.Any(e => e.IDPP == id);
        }
    }
}
