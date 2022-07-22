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
    public class LegajosTestsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public LegajosTestsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/LegajosTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegajosTest>>> GetTBA_LEGAJOSTEST()
        {
          if (_context.TBA_LEGAJOSTEST == null)
          {
              return NotFound();
          }
            return await _context.TBA_LEGAJOSTEST.ToListAsync();
        }

        // GET: api/LegajosTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegajosTest>> GetLegajosTest(int id)
        {
          if (_context.TBA_LEGAJOSTEST == null)
          {
              return NotFound();
          }
            var legajosTest = await _context.TBA_LEGAJOSTEST.FindAsync(id);

            if (legajosTest == null)
            {
                return NotFound();
            }

            return legajosTest;
        }

        // PUT: api/LegajosTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegajosTest(int id, LegajosTest legajosTest)
        {
            if (id != legajosTest.Legajo)
            {
                return BadRequest();
            }

            _context.Entry(legajosTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegajosTestExists(id))
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

        // POST: api/LegajosTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LegajosTest>> PostLegajosTest(LegajosTest legajosTest)
        {
          if (_context.TBA_LEGAJOSTEST == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_LEGAJOSTEST'  is null.");
          }
            _context.TBA_LEGAJOSTEST.Add(legajosTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegajosTest", new { id = legajosTest.Legajo }, legajosTest);
        }

        // DELETE: api/LegajosTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegajosTest(int id)
        {
            if (_context.TBA_LEGAJOSTEST == null)
            {
                return NotFound();
            }
            var legajosTest = await _context.TBA_LEGAJOSTEST.FindAsync(id);
            if (legajosTest == null)
            {
                return NotFound();
            }

            _context.TBA_LEGAJOSTEST.Remove(legajosTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegajosTestExists(int id)
        {
            return (_context.TBA_LEGAJOSTEST?.Any(e => e.Legajo == id)).GetValueOrDefault();
        }
    }
}
