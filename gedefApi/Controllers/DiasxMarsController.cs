using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.PlanillaRoles;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiasxMarsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public DiasxMarsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/DiasxMars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiasxMar>>> GetTBA_DIASXMAR()
        {
          if (_context.TBA_DIASXMAR == null)
          {
              return NotFound();
          }
            return await _context.TBA_DIASXMAR.ToListAsync();
        }

        // GET: api/DiasxMars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiasxMar>> GetDiasxMar(int id)
        {
          if (_context.TBA_DIASXMAR == null)
          {
              return NotFound();
          }
            var diasxMar = await _context.TBA_DIASXMAR.FindAsync(id);

            if (diasxMar == null)
            {
                return NotFound();
            }

            return diasxMar;
        }

        [HttpGet("byIdMarea/{idMarea}")]
        public async Task<ActionResult<DiasxMar>> GetByIdMarea(int idMarea)
        {
            if (_context.TBA_DIASXMAR == null)
            {
                return NotFound();
            }
            var diasXMar = await _context.TBA_DIASXMAR.ToListAsync();
            var item = diasXMar.FindAll(e => e.IDMAREA == idMarea);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        // GET: api/DiasxMars/5

        // PUT: api/DiasxMars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiasxMar(int id, DiasxMar diasxMar)
        {
            if (id != diasxMar.ID)
            {
                return BadRequest();
            }

            _context.Entry(diasxMar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiasxMarExists(id))
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

        // POST: api/DiasxMars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiasxMar>> PostDiasxMar(DiasxMar diasxMar)
        {
          if (_context.TBA_DIASXMAR == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_DIASXMAR'  is null.");
          }
            _context.TBA_DIASXMAR.Add(diasxMar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiasxMar", new { id = diasxMar.ID }, diasxMar);
        }

        // DELETE: api/DiasxMars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiasxMar(int id)
        {
            if (_context.TBA_DIASXMAR == null)
            {
                return NotFound();
            }
            var diasxMar = await _context.TBA_DIASXMAR.FindAsync(id);
            if (diasxMar == null)
            {
                return NotFound();
            }

            _context.TBA_DIASXMAR.Remove(diasxMar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiasxMarExists(int id)
        {
            return (_context.TBA_DIASXMAR?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
