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
    public class FrancosTotalController : ControllerBase
    {
        private readonly GedefDbContext _context;
        public FrancosTotalController(GedefDbContext context)
        {
            _context = context;
        }

        // GET: api/FrancosTotal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrancosTotal>>> GetVST_FRANCOS_TOTAL()

        {
            if (_context.VST_FRANCOS_TOTAL == null)
            {
                return NotFound();
            }
            return await _context.VST_FRANCOS_TOTAL.ToListAsync();
        }

        // GET: api/FrancosTotal/5
        [HttpGet("{idlegajo}")]
        public async Task<ActionResult<FrancosTotal>> GetFrancosByIdLegajo(int idlegajo)

        {
            if (_context.VST_FRANCOS_TOTAL == null)
            {
                return NotFound();
            }
            var francos = await _context.VST_FRANCOS_TOTAL.ToListAsync();
            var francosByIdLegajo = francos.FindAll(e => e.IDLEGAJO == idlegajo);

            if (francosByIdLegajo == null)
            {
                return NotFound();
            }
            return Ok(francosByIdLegajo);
        }
    }
}
