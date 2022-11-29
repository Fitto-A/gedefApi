using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.PlanillaRoles;
using EmailService;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public RolesController(GedefDbContext context)
        {
            _context = context;
            
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetTBA_ROLES()
        {
            return await _context.TBA_ROLES.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoles(int id)
        {
            var roles = await _context.TBA_ROLES.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }


        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, Roles roles)
        {
            if (id != roles.IDROL)
            {
                return BadRequest();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roles>> PostRoles(Roles roles)
        {
            _context.TBA_ROLES.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.IDROL }, roles);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var roles = await _context.TBA_ROLES.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.TBA_ROLES.Remove(roles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return _context.TBA_ROLES.Any(e => e.IDROL == id);
        }
    }
}
