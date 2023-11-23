﻿using System;
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
    public class SueldosController : ControllerBase
    {
        private readonly GedefDbContext _context;

        public SueldosController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/Sueldos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sueldos>>> GetTBA_SUELDOS()
        {
          if (_context.TBA_SUELDOS == null)
          {
              return NotFound();
          }
            return await _context.TBA_SUELDOS.ToListAsync();
        }

        // GET: api/Sueldos/5
        [HttpGet("{idrol}/{idemp}")]
        public async Task<ActionResult<Sueldos>> GetSueldos(int idrol, string idemp)
        {
          if (_context.TBA_SUELDOS == null)
          {
              return NotFound();
          }
            var sueldos = await _context.TBA_SUELDOS.FindAsync(idrol, idemp);

            if (sueldos == null)
            {
                return NotFound();
            }

            return sueldos;
        }

        // PUT: api/Sueldos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idrol}/{idemp}")]
        public async Task<IActionResult> PutSueldos(int idrol, string idemp, Sueldos sueldos)
        {
            if (idrol != sueldos.IDROL && idemp != sueldos.IDEMP)
            {
                return BadRequest();
            }

            _context.Entry(sueldos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SueldosExists(idrol, idemp))
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

        // POST: api/Sueldos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sueldos>> PostSueldos(Sueldos sueldos)
        {
          if (_context.TBA_SUELDOS == null)
          {
              return Problem("Entity set 'GedefDbContext.TBA_SUELDOS'  is null.");
          }
            _context.TBA_SUELDOS.Add(sueldos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SueldosExists(sueldos.IDROL, sueldos.IDEMP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSueldos", new { idrol = sueldos.IDROL, idemp = sueldos.IDEMP }, sueldos);
        }

        // DELETE: api/Sueldos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSueldos(int id)
        {
            if (_context.TBA_SUELDOS == null)
            {
                return NotFound();
            }
            var sueldos = await _context.TBA_SUELDOS.FindAsync(id);
            if (sueldos == null)
            {
                return NotFound();
            }

            _context.TBA_SUELDOS.Remove(sueldos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SueldosExists(int id, string idemp)
        {
            return (_context.TBA_SUELDOS?.Any(e => e.IDROL == id)).GetValueOrDefault();
        }
    }
}
