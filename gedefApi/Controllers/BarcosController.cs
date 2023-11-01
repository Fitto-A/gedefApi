using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public BarcosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Barcos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barcos>>> GetTBA_BARCOS()
        {
          if (_context.TBA_BARCOS == null)
          {
              return NotFound();
          }
            return await _context.TBA_BARCOS.ToListAsync();
        }

        [HttpGet("byArmador/{idPerfil}")]
        //[Authorize(Roles = ("ARMADOR"))]
        public async Task<ActionResult<Barcos>> GetByIdPerfil(int idPerfil)
        {
            if (_context.TBA_BARCOS == null)
            {
                return NotFound();
            }
            var barcos = await _context.TBA_BARCOS.ToListAsync();
            var barcosActivos = barcos.FindAll(e => e.ACTBAR == 1);
            var item = barcosActivos.FindAll(e => e.ARMADOR1 == idPerfil || e.ARMADOR2 == idPerfil 
                || e.ARMADOR3 == idPerfil || e.ARMADOR4 == idPerfil || e.ARMADOR5 == idPerfil || e.ARMADOR6 == idPerfil
                || e.ARMADOR7 == idPerfil || e.ARMADOR8 == idPerfil || e.ARMADOR9 == idPerfil || e.ARMADOR10 == idPerfil);
            if(item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("byCapitan/{idPerfil}")]
        //[Authorize(Roles = ("ARMADOR"))]
        public async Task<ActionResult<Barcos>> GetByIdPerfilCapi(int idPerfil)
        {
            if (_context.TBA_BARCOS == null)
            {
                return NotFound();
            }
            var barcos = await _context.TBA_BARCOS.ToListAsync();
            var barcosActivos = barcos.FindAll(e => e.ACTBAR == 1);
            var item = barcosActivos.FindAll(e => e.CAPITAN1 == idPerfil || e.CAPITAN2 == idPerfil
                || e.CAPITAN3 == idPerfil || e.CAPITAN4 == idPerfil);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("byRrhh/{idPerfil}")]
        //[Authorize(Roles = ("ARMADOR"))]
        public async Task<ActionResult<Barcos>> GetByIdPerfilRrhh(int idPerfil)
        {
            if (_context.TBA_BARCOS == null)
            {
                return NotFound();
            }
            var barcos = await _context.TBA_BARCOS.ToListAsync();
            var barcosActivos = barcos.FindAll(e => e.ACTBAR == 1);
            if (barcosActivos == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(barcosActivos);
            }
        }

        // GET: api/Barcos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barcos>> GetBarcos(int id)
        {
          if (_context.TBA_BARCOS == null)
          {
              return NotFound();
          }
            var barcos = await _context.TBA_BARCOS.FindAsync(id);

            if (barcos == null)
            {
                return NotFound();
            }

            return barcos;
        }

        // PUT: api/Barcos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarcos(int id, Barcos barcos)
        {
            if (id != barcos.CODBAR)
            {
                return BadRequest();
            }

            _context.Entry(barcos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarcosExists(id))
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

        // POST: api/Barcos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barcos>> PostBarcos(Barcos barcos)
        {
          if (_context.TBA_BARCOS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_BARCOS'  is null.");
          }
            _context.TBA_BARCOS.Add(barcos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarcos", new { id = barcos.CODBAR }, barcos);
        }

        // DELETE: api/Barcos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarcos(int id)
        {
            if (_context.TBA_BARCOS == null)
            {
                return NotFound();
            }
            var barcos = await _context.TBA_BARCOS.FindAsync(id);
            if (barcos == null)
            {
                return NotFound();
            }

            _context.TBA_BARCOS.Remove(barcos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarcosExists(int id)
        {
            return (_context.TBA_BARCOS?.Any(e => e.CODBAR == id)).GetValueOrDefault();
        }
    }
}
