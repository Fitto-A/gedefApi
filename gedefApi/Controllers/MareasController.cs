using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using EmailService;
using Microsoft.Data.SqlClient;
using System.Data;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MareasController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public MareasController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Mareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREAS()
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            return await _context.TBA_MAREAS.ToListAsync();
        }



        [HttpGet("fifty/{mareasCount}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASFifty(int mareasCount)
        {
            int pageSize = 50;

            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS
                .Where(e => e.ESTADO != "ELIMINADA")
                .OrderByDescending(m => m.IDMAR)
                .Skip((mareasCount - 1) * pageSize)
                .Take(50)
                .ToListAsync();
            //var mareasNotDeleted = mareas.FindAll(e => e.ESTADO != "ELIMINADA");
            return Ok(mareas);
        }
       
        [HttpGet("activasYConfeccion")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASActivasyConfeccion()
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var item = mareas.FindAll(e => e.ESTADO == "ACTIVA" || e.ESTADO == "CONFECCION");
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [HttpGet("activasByShip/{codbar}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASActivasByShip(int codbar)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var item = mareas.FindAll(e => e.ESTADO == "ACTIVA" & e.CODBAR == codbar);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [HttpGet("getByShipAndYear/{year}/{codbar}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetByShipAndYear(string year, int codbar)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }

            var mareas = await _context.TBA_MAREAS.OrderByDescending(m => m.IDMAR).ToListAsync();
            var items = mareas.FindAll(e => e.ESTADO != "ELIMINADA" & e.ANO == year &&  e.CODBAR == codbar);

            if (items == null || items.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }
        }
        [HttpGet("getByYear/{year}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetByYear(string year)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }

            var mareas = await _context.TBA_MAREAS.OrderByDescending(m => m.IDMAR).ToListAsync();
            var items = mareas.FindAll(e => e.ESTADO != "ELIMINADA" & e.ANO == year);

            if (items == null || items.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }
        }
        [HttpGet("getByCodbar/{codbar}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetByCodbar(int codbar)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }

            var mareas = await _context.TBA_MAREAS.OrderByDescending(m => m.IDMAR).ToListAsync();
            var items = mareas.FindAll(e => e.ESTADO != "ELIMINADA" & e.CODBAR == codbar);

            if (items == null || items.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }
        }
        [HttpGet("getNewMarea/{codbar}/{year}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetNewMarea(int codbar, string year)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var item = mareas.FindAll(e => e.ESTADO == "CONFECCION" & e.CODBAR == codbar & e.ANO == year);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpGet("getLastNumMarea/{codbar}/{year}")]
        public async Task<ActionResult<IEnumerable<Mareas>>> GetTBA_MAREASGetLasNumMarea(int codbar, string year)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.ToListAsync();
            var mareasFiltered = mareas.FindAll(m => m.CODBAR == codbar & m.ANO == year & m.ESTADO != "ELIMINADA" );
            if (mareasFiltered == null) {
                return Ok(0);
            } else 
            {
                var item = mareasFiltered.Max(i => i.NUMMAREA);
                return Ok(item);
            }
        }

        // GET: api/Mareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mareas>> GetMareas(int id)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.FindAsync(id);

            if (mareas == null)
            {
                return NotFound();
            }

            return mareas;
        }

        // PUT: api/Mareas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMareas(int id, Mareas mareas)
        {
            if (id != mareas.IDMAR)
            {
                return BadRequest();
            }

            _context.Entry(mareas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MareasExists(id))
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

        // POST: api/Mareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mareas>> PostMareas(Mareas mareas)
        {
            if (_context.TBA_MAREAS == null)
            {
                return Problem("Entity set 'GedefDbContext.TBA_MAREAS'  is null.");
            }
            _context.TBA_MAREAS.Add(mareas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMareas", new { id = mareas.IDMAR }, mareas);
        }

        // DELETE: api/Mareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMareas(int id)
        {
            if (_context.TBA_MAREAS == null)
            {
                return NotFound();
            }
            var mareas = await _context.TBA_MAREAS.FindAsync(id);
            if (mareas == null)
            {
                return NotFound();
            }

            _context.TBA_MAREAS.Remove(mareas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MareasExists(int id)
        {
            return (_context.TBA_MAREAS?.Any(e => e.IDMAR == id)).GetValueOrDefault();
        }
    }
}
