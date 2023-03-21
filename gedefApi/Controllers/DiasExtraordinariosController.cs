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
    public class DiasExtraordinariosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public DiasExtraordinariosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/DiasExtraordinarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiasExtraordinarios>>> GetTBA_DIASEXTRAORDINARIOS()
        {
            return await _context.TBA_DIASEXTRAORDINARIOS.ToListAsync();
        }

        // GET: api/DiasExtraordinarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiasExtraordinarios>> GetDiasExtraordinarios(int id)
        {
            var diasExtraordinarios = await _context.TBA_DIASEXTRAORDINARIOS.FindAsync(id);

            if (diasExtraordinarios == null)
            {
                return NotFound();
            }

            return diasExtraordinarios;
        }

        // PUT: api/DiasExtraordinarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiasExtraordinarios(int id, DiasExtraordinarios diasExtraordinarios)
        {
            if (id != diasExtraordinarios.ID)
            {
                return BadRequest();
            }

            _context.Entry(diasExtraordinarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiasExtraordinariosExists(id))
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

        // POST: api/DiasExtraordinarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiasExtraordinarios>> PostDiasExtraordinarios(DiasExtraordinarios diasExtraordinarios)
        {
            _context.TBA_DIASEXTRAORDINARIOS.Add(diasExtraordinarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiasExtraordinarios", new { id = diasExtraordinarios.ID }, diasExtraordinarios);
        }

        // DELETE: api/DiasExtraordinarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiasExtraordinarios(int id)
        {
            var diasExtraordinarios = await _context.TBA_DIASEXTRAORDINARIOS.FindAsync(id);
            if (diasExtraordinarios == null)
            {
                return NotFound();
            }

            _context.TBA_DIASEXTRAORDINARIOS.Remove(diasExtraordinarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiasExtraordinariosExists(int id)
        {
            return _context.TBA_DIASEXTRAORDINARIOS.Any(e => e.ID == id);
        }
    }
}
