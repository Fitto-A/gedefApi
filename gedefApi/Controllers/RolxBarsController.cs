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
    public class RolxBarsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public RolxBarsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/RolxBars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolxBar>>> GetTBA_ROLXBAR()
        {
          if (_context.TBA_ROLXBAR == null)
          {
              return NotFound();
          }
            return await _context.TBA_ROLXBAR.ToListAsync();
        }

        // GET: api/RolxBars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolxBar>> GetRolxBar(int id)
        {
          if (_context.TBA_ROLXBAR == null)
          {
              return NotFound();
          }
            var rolxBar = await _context.TBA_ROLXBAR.FindAsync(id);

            if (rolxBar == null)
            {
                return NotFound();
            }

            return rolxBar;
        }

        // PUT: api/RolxBars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolxBar(int id, RolxBar rolxBar)
        {
            if (id != rolxBar.CODBAR)
            {
                return BadRequest();
            }

            _context.Entry(rolxBar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolxBarExists(id))
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

        // POST: api/RolxBars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolxBar>> PostRolxBar(RolxBar rolxBar)
        {
          if (_context.TBA_ROLXBAR == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_ROLXBAR'  is null.");
          }
            _context.TBA_ROLXBAR.Add(rolxBar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolxBar", new { id = rolxBar.CODBAR }, rolxBar);
        }

        // DELETE: api/RolxBars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolxBar(int id)
        {
            if (_context.TBA_ROLXBAR == null)
            {
                return NotFound();
            }
            var rolxBar = await _context.TBA_ROLXBAR.FindAsync(id);
            if (rolxBar == null)
            {
                return NotFound();
            }

            _context.TBA_ROLXBAR.Remove(rolxBar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolxBarExists(int id)
        {
            return (_context.TBA_ROLXBAR?.Any(e => e.CODBAR == id)).GetValueOrDefault();
        }
    }
}
