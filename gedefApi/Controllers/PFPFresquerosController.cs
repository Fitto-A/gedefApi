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
    public class PFPFresquerosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public PFPFresquerosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/PFPFresqueros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PFPFresqueros>>> GetTBA_PFPFresqueros()
        {
            return await _context.TBA_PFPFresqueros.ToListAsync();
        }

        // GET: api/PFPFresqueros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PFPFresqueros>> GetPFPFresqueros(int id)
        {
            var pFPFresqueros = await _context.TBA_PFPFresqueros.FindAsync(id);

            if (pFPFresqueros == null)
            {
                return NotFound();
            }

            return pFPFresqueros;
        }

        // PUT: api/PFPFresqueros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPFPFresqueros(int id, PFPFresqueros pFPFresqueros)
        {
            if (id != pFPFresqueros.IDPFP)
            {
                return BadRequest();
            }

            _context.Entry(pFPFresqueros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PFPFresquerosExists(id))
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

        // POST: api/PFPFresqueros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PFPFresqueros>> PostPFPFresqueros(PFPFresqueros pFPFresqueros)
        {
            _context.TBA_PFPFresqueros.Add(pFPFresqueros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPFPFresqueros", new { id = pFPFresqueros.IDPFP }, pFPFresqueros);
        }

        // DELETE: api/PFPFresqueros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePFPFresqueros(int id)
        {
            var pFPFresqueros = await _context.TBA_PFPFresqueros.FindAsync(id);
            if (pFPFresqueros == null)
            {
                return NotFound();
            }

            _context.TBA_PFPFresqueros.Remove(pFPFresqueros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PFPFresquerosExists(int id)
        {
            return _context.TBA_PFPFresqueros.Any(e => e.IDPFP == id);
        }
    }
}
