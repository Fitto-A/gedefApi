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
    public class UsuariosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public UsuariosController(GedefDbContext context)
        {
            _context = context;
        }
    

        //GET: api/Usuarios
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetTBA_USUARIOS()
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            return await _context.TBA_USUARIOS.ToListAsync();
        }

        ////GET: api/Usuarios/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        //{
        //    if (_context.TBA_USUARIOS == null)
        //    {
        //        return NotFound();
        //    }
        //    var usuarios = await _context.TBA_USUARIOS.FindAsync(id);

        //    if (usuarios == null)
        //    {
        //        return NotFound();
        //    }

        //    return usuarios;
        //}

        [HttpGet("{usuario}")]
        public async Task<ActionResult<Usuarios>> GetByUsuario(String user)
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            var usuarios = await _context.TBA_USUARIOS.ToListAsync();
            var item = usuarios.SingleOrDefault(i => i.USUARIO == user);
            
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios)
        {
            if (id != usuarios.IDPERFIL)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            if (_context.TBA_USUARIOS == null)
            {
                return Problem("Entity set 'GedefDbContext.TBA_USUARIOS'  is null.");
            }
            _context.TBA_USUARIOS.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.IDPERFIL }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(int id)
        {
            if (_context.TBA_USUARIOS == null)
            {
                return NotFound();
            }
            var usuarios = await _context.TBA_USUARIOS.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.TBA_USUARIOS.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosExists(int id)
        {
            return (_context.TBA_USUARIOS?.Any(e => e.IDPERFIL == id)).GetValueOrDefault();
        }
    }
}
