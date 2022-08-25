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
    public class PartePescasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public PartePescasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/PartePescas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartePesca>>> GetTBA_PARTEPESCA()
        {
          if (_context.TBA_PARTEPESCA == null)
          {
              return NotFound();
          }
            return await _context.TBA_PARTEPESCA.ToListAsync();
        }

        // GET: api/PartePescas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartePesca>> GetPartePesca(int id)
        {
          if (_context.TBA_PARTEPESCA == null)
          {
              return NotFound();
          }
            var partePesca = await _context.TBA_PARTEPESCA.FindAsync(id);

            if (partePesca == null)
            {
                return NotFound();
            }

            return partePesca;
        }

        // PUT: api/PartePescas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartePesca(int id, PartePesca partePesca)
        {
            if (id != partePesca.IDPP)
            {
                return BadRequest();
            }

            _context.Entry(partePesca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartePescaExists(id))
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

        // POST: api/PartePescas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartePesca>> PostPartePesca(PartePesca partePesca)
        {
          if (_context.TBA_PARTEPESCA == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_PARTEPESCA'  is null.");
          }
            _context.TBA_PARTEPESCA.Add(partePesca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartePesca", new { id = partePesca.IDPP }, partePesca);
        }

        // DELETE: api/PartePescas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartePesca(int id)
        {
            if (_context.TBA_PARTEPESCA == null)
            {
                return NotFound();
            }
            var partePesca = await _context.TBA_PARTEPESCA.FindAsync(id);
            if (partePesca == null)
            {
                return NotFound();
            }

            _context.TBA_PARTEPESCA.Remove(partePesca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartePescaExists(int id)
        {
            return (_context.TBA_PARTEPESCA?.Any(e => e.IDPP == id)).GetValueOrDefault();
        }
    }
}
