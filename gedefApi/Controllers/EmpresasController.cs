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
    public class EmpresasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public EmpresasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresas>>> GetTBA_EMPRESAS()
        {
          if (_context.TBA_EMPRESAS == null)
          {
              return NotFound();
          }
            return await _context.TBA_EMPRESAS.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresas>> GetEmpresas(string id)
        {
          if (_context.TBA_EMPRESAS == null)
          {
              return NotFound();
          }
            var empresas = await _context.TBA_EMPRESAS.FindAsync(id);

            if (empresas == null)
            {
                return NotFound();
            }

            return empresas;
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresas(string id, Empresas empresas)
        {
            if (id != empresas.ID)
            {
                return BadRequest();
            }

            _context.Entry(empresas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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

        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empresas>> PostEmpresas(Empresas empresas)
        {
          if (_context.TBA_EMPRESAS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_EMPRESAS'  is null.");
          }
            _context.TBA_EMPRESAS.Add(empresas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpresasExists(empresas.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpresas", new { id = empresas.ID }, empresas);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresas(string id)
        {
            if (_context.TBA_EMPRESAS == null)
            {
                return NotFound();
            }
            var empresas = await _context.TBA_EMPRESAS.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            _context.TBA_EMPRESAS.Remove(empresas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresasExists(string id)
        {
            return (_context.TBA_EMPRESAS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
