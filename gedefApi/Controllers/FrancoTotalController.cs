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
    public class FrancoTotalController : ControllerBase
    {
        private readonly GedefDbContext _context;
        public FrancoTotalController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/FrancoTotal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrancoTotal>>> GetVST_FRANCO_TOTAL()

        {
            if (_context.VST_FRANCO_TOTAL == null)
            {
                return NotFound();
            }
            return await _context.VST_FRANCO_TOTAL.ToListAsync();
        }

        // GET: api/FrancoTotal/5
        [HttpGet("{idlegajo}")]
        public async Task<ActionResult<FrancoTotal>> GetFrancosByIdLegajo(int idlegajo)

        {
            if (_context.VST_FRANCO_TOTAL == null)
            {
                return NotFound();
            }
            var francos = await _context.VST_FRANCO_TOTAL.ToListAsync();
            var francosByIdLegajo = francos.FindAll(e => e.IDLEGAJO == idlegajo);

            if (francosByIdLegajo == null)
            {
                return NotFound();
            }
            return Ok(francosByIdLegajo);
        }
    }
}
