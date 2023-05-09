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
    public class ActaDescargaPPsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public ActaDescargaPPsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/ActaDescargaPPs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActaDescargaPP>>> GetTBA_ACTADESCARGA_PP()
        {
          if (_context.TBA_ACTADESCARGA_PP == null)
          {
              return NotFound();
          }
            return await _context.TBA_ACTADESCARGA_PP.ToListAsync();
        }

        // GET: api/ActaDescargaPPs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActaDescargaPP>> GetActaDescargaPP(int id)
        {
          if (_context.TBA_ACTADESCARGA_PP == null)
          {
              return NotFound();
          }
            var actaDescargaPP = await _context.TBA_ACTADESCARGA_PP.FindAsync(id);

            if (actaDescargaPP == null)
            {
                return NotFound();
            }

            return actaDescargaPP;
        }

        [HttpGet("byIdMarea/{idMar}")]
        public async Task<ActionResult<ActaDescargaPP>> GetActaDescargaPPByIdMar(int idMar)
        {
            if (_context.TBA_ACTADESCARGA_PP == null)
            {
                return NotFound();
            }
            var actaDescargaPP = await _context.TBA_ACTADESCARGA_PP.ToListAsync();
            var item = actaDescargaPP.FindAll(a => a.IDMAR == idMar);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("byActa/{numActa}")]
        public async Task<ActionResult<ActaDescargaPP>> GetActaDescargaPPByActa (int numActa)
        {
            if (_context.TBA_ACTADESCARGA_PP == null)
            {
                return NotFound();
            }
            var actaDescargaPP = await _context.TBA_ACTADESCARGA_PP.ToListAsync();
            var item = actaDescargaPP.FindAll(a => a.IDAD == numActa);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT: api/ActaDescargaPPs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActaDescargaPP(int id, ActaDescargaPP actaDescargaPP)
        {
            if (id != actaDescargaPP.ID)
            {
                return BadRequest();
            }

            _context.Entry(actaDescargaPP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActaDescargaPPExists(id))
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

        // POST: api/ActaDescargaPPs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActaDescargaPP>> PostActaDescargaPP(ActaDescargaPP actaDescargaPP)
        {
          if (_context.TBA_ACTADESCARGA_PP == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_ACTADESCARGA_PP'  is null.");
          }
            _context.TBA_ACTADESCARGA_PP.Add(actaDescargaPP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActaDescargaPP", new { id = actaDescargaPP.ID }, actaDescargaPP);
        }

        // DELETE: api/ActaDescargaPPs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActaDescargaPP(int id)
        {
            if (_context.TBA_ACTADESCARGA_PP == null)
            {
                return NotFound();
            }
            var actaDescargaPP = await _context.TBA_ACTADESCARGA_PP.FindAsync(id);
            if (actaDescargaPP == null)
            {
                return NotFound();
            }

            _context.TBA_ACTADESCARGA_PP.Remove(actaDescargaPP);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActaDescargaPPExists(int id)
        {
            return (_context.TBA_ACTADESCARGA_PP?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
