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
    public class PFPCongeladoresController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public PFPCongeladoresController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/PFPCongeladores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PFPCongeladores>>> GetTBA_PFPCongeladores()
        {
            return await _context.TBA_PFPCongeladores.ToListAsync();
        }

        // GET: api/PFPCongeladores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PFPCongeladores>> GetPFPCongeladores(int id)
        {
            var pFPCongeladores = await _context.TBA_PFPCongeladores.FindAsync(id);

            if (pFPCongeladores == null)
            {
                return NotFound();
            }

            return pFPCongeladores;
        }

        // PUT: api/PFPCongeladores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPFPCongeladores(int id, PFPCongeladores pFPCongeladores)
        {
            if (id != pFPCongeladores.IDPFP)
            {
                return BadRequest();
            }

            _context.Entry(pFPCongeladores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PFPCongeladoresExists(id))
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

        // POST: api/PFPCongeladores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PFPCongeladores>> PostPFPCongeladores(PFPCongeladores pFPCongeladores)
        {
            _context.TBA_PFPCongeladores.Add(pFPCongeladores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPFPCongeladores", new { id = pFPCongeladores.IDPFP }, pFPCongeladores);
        }

        // DELETE: api/PFPCongeladores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePFPCongeladores(int id)
        {
            var pFPCongeladores = await _context.TBA_PFPCongeladores.FindAsync(id);
            if (pFPCongeladores == null)
            {
                return NotFound();
            }

            _context.TBA_PFPCongeladores.Remove(pFPCongeladores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PFPCongeladoresExists(int id)
        {
            return _context.TBA_PFPCongeladores.Any(e => e.IDPFP == id);
        }
    }
}
