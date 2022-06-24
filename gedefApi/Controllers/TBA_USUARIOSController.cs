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
    public class TBA_USUARIOSController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public TBA_USUARIOSController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/TBA_USUARIOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBA_USUARIOS>>> GetTBA_USUARIOS()
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            return await _context.TBA_USUARIOS.ToListAsync();
        }

        // GET: api/TBA_USUARIOS/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TBA_USUARIOS>> GetTBA_USUARIOS(int id)
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            var tBA_USUARIOS = await _context.TBA_USUARIOS.FindAsync(id);

            if (tBA_USUARIOS == null)
            {
                return NotFound();
            }

            return tBA_USUARIOS;
        }

        // PUT: api/TBA_USUARIOS/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTBA_USUARIOS(int id, TBA_USUARIOS tBA_USUARIOS)
        {
            if (id != tBA_USUARIOS.USUARIOID)
            {
                return BadRequest();
            }

            _context.Entry(tBA_USUARIOS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBA_USUARIOSExists(id))
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

        // POST: api/TBA_USUARIOS
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TBA_USUARIOS>> PostTBA_USUARIOS(TBA_USUARIOS tBA_USUARIOS)
        {
            var temp = _context.TBA_USUARIOS
                .Where(x => x.USUARIO == tBA_USUARIOS.USUARIO && x.CONTRASEÑA == tBA_USUARIOS.CONTRASEÑA)
                .FirstOrDefault();

            if (temp == null)
            {
                _context.TBA_USUARIOS.Add(tBA_USUARIOS);
                await _context.SaveChangesAsync();
            }
            else
                tBA_USUARIOS = temp;
            return Ok(tBA_USUARIOS);
        }
        // DELETE: api/TBA_USUARIOS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTBA_USUARIOS(int id)
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            var tBA_USUARIOS = await _context.TBA_USUARIOS.FindAsync(id);
            if (tBA_USUARIOS == null)
            {
                return NotFound();
            }

            _context.TBA_USUARIOS.Remove(tBA_USUARIOS);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TBA_USUARIOSExists(int id)
        {
            return (_context.TBA_USUARIOS?.Any(e => e.USUARIOID == id)).GetValueOrDefault();
        }
    }
}
