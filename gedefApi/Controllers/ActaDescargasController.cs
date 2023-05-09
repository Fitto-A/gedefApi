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
    public class ActaDescargasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public ActaDescargasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/ActaDescargas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActaDescarga>>> GetTBA_ACTADESCARGA()
        {
          if (_context.TBA_ACTADESCARGA == null)
          {
              return NotFound();
          }
            return await _context.TBA_ACTADESCARGA.ToListAsync();
        }

        // GET: api/ActaDescargas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActaDescarga>> GetActaDescarga(int id)
        {
          if (_context.TBA_ACTADESCARGA == null)
          {
              return NotFound();
          }
            var actaDescarga = await _context.TBA_ACTADESCARGA.FindAsync(id);

            if (actaDescarga == null)
            {
                return NotFound();
            }

            return actaDescarga;
        }

        [HttpGet("byBar/{codbar}")]
        public async Task<ActionResult<ActaDescarga>> GetActaDescargaByCodbar(int codbar)
        {
            if(_context.TBA_ACTADESCARGA == null)
            {
                return NotFound();
            }
            var actaDescarga = await _context.TBA_ACTADESCARGA.ToListAsync();
            var item = actaDescarga.FindAll(e => e.CODBAR == codbar);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("byActa/{numActa}")]
        public async Task<ActionResult<ActaDescarga>> GetActaDescargaByActa(int numActa)
        {
            if (_context.TBA_ACTADESCARGA == null)
            {
                return NotFound();
            }
            var actaDescarga = await _context.TBA_ACTADESCARGA.ToListAsync();
            var item = actaDescarga.FindAll(a => a.NUMACTA == numActa);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpGet("byIdMarea/{idMar}")]
        public async Task<ActionResult<ActaDescarga>> GetActaDescargaByIdMar(int idMar)
        {
            if (_context.TBA_ACTADESCARGA == null)
            {
                return NotFound();
            }
            var actaDescarga = await _context.TBA_ACTADESCARGA.ToListAsync();
            var item = actaDescarga.FindAll(a => a.IDMAR == idMar);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // PUT: api/ActaDescargas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActaDescarga(int id, ActaDescarga actaDescarga)
        {
            if (id != actaDescarga.ID)
            {
                return BadRequest();
            }

            _context.Entry(actaDescarga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaDescargaExists(id))
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

        // POST: api/ActaDescargas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActaDescarga>> PostActaDescarga(ActaDescarga actaDescarga)
        {
          if (_context.TBA_ACTADESCARGA == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_ACTADESCARGA'  is null.");
          }
            _context.TBA_ACTADESCARGA.Add(actaDescarga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActaDescarga", new { id = actaDescarga.ID }, actaDescarga);
        }

        // DELETE: api/ActaDescargas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActaDescarga(int id)
        {
            if (_context.TBA_ACTADESCARGA == null)
            {
                return NotFound();
            }
            var actaDescarga = await _context.TBA_ACTADESCARGA.FindAsync(id);
            if (actaDescarga == null)
            {
                return NotFound();
            }

            _context.TBA_ACTADESCARGA.Remove(actaDescarga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActaDescargaExists(int id)
        {
            return (_context.TBA_ACTADESCARGA?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
