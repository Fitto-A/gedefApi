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
    public class RolxBarxMarsController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public RolxBarxMarsController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/RolxBarxMars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolxBarxMar>>> GetTBA_ROLXBARXMAR()
        {
          if (_context.TBA_ROLXBARXMAR == null)
          {
              return NotFound();
          }
            return await _context.TBA_ROLXBARXMAR.ToListAsync();
        }

        // GET: api/RolxBarxMars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolxBarxMar>> GetRolxBarxMar(int id)
        {
          if (_context.TBA_ROLXBARXMAR == null)
          {
              return NotFound();
          }
            var rolxBarxMar = await _context.TBA_ROLXBARXMAR.FindAsync(id);

            if (rolxBarxMar == null)
            {
                return NotFound();
            }

            return rolxBarxMar;
        }

        // PUT: api/RolxBarxMars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolxBarxMar(int id, RolxBarxMar rolxBarxMar)
        {
            if (id != rolxBarxMar.CODROLXBARXMAR)
            {
                return BadRequest();
            }

            _context.Entry(rolxBarxMar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolxBarxMarExists(id))
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

        // POST: api/RolxBarxMars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolxBarxMar>> PostRolxBarxMar(RolxBarxMar rolxBarxMar)
        {
          if (_context.TBA_ROLXBARXMAR == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_ROLXBARXMAR'  is null.");
          }
            _context.TBA_ROLXBARXMAR.Add(rolxBarxMar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolxBarxMar", new { id = rolxBarxMar.CODROLXBARXMAR }, rolxBarxMar);
        }

        // DELETE: api/RolxBarxMars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolxBarxMar(int id)
        {
            if (_context.TBA_ROLXBARXMAR == null)
            {
                return NotFound();
            }
            var rolxBarxMar = await _context.TBA_ROLXBARXMAR.FindAsync(id);
            if (rolxBarxMar == null)
            {
                return NotFound();
            }

            _context.TBA_ROLXBARXMAR.Remove(rolxBarxMar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolxBarxMarExists(int id)
        {
            return (_context.TBA_ROLXBARXMAR?.Any(e => e.CODROLXBARXMAR == id)).GetValueOrDefault();
        }
    }
}
