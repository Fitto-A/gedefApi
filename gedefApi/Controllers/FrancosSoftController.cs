using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using gedefApi.Models.RRHH;
using Microsoft.AspNetCore.Http.HttpResults;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrancosSoftController : ControllerBase
    {
        private readonly GedefDbContext _context;
        public FrancosSoftController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/FrancosSoft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrancosSoft>>> GetVST_FRANCOS_SOFT()

        {
            if (_context.VST_FRANCOS_SOFT == null)
            {
                return NotFound();
            }
            return await _context.VST_FRANCOS_SOFT.ToListAsync();
        }

        // GET: api/FrancosSoft/5
        [HttpGet("{idlegajo}")]
        public async Task<ActionResult<FrancosSoft>> GetFrancosByIdLegajo(string idlegajo)

        {
            if (_context.VST_FRANCOS_SOFT == null)
            {
                return NotFound();
            }
            var francos = await _context.VST_FRANCOS_SOFT.ToListAsync();
            var francosByIdLegajo = francos.FindAll(e => e.IDLEGAJO == idlegajo);

            if (francosByIdLegajo == null)
            {
                return NotFound();
            }
            return Ok(francosByIdLegajo);
        }
    }
}
