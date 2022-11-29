using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gedefApi.Models;
using EmailService;

namespace gedefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendsController : ControllerBase
    {
        private readonly GedefDbContext _context;
        private readonly IEmailSender _emailSender;
        public EmailSendsController(GedefDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: api/EmailSends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailSend>>> GetTBA_EMAILSEND()
        {
            //var message = new Message(new string[] { "afittipaldi@grupoveraz.com.ar" }, "Test desde la API", "This is the content from our email.");
            //await _emailSender.SendEmailAsync(message);
            return await _context.TBA_EMAILSEND.ToListAsync();
        }

        // GET: api/EmailSends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailSend>> GetEmailSend(int id)
        {
            var emailSend = await _context.TBA_EMAILSEND.FindAsync(id);

            if (emailSend == null)
            {
                return NotFound();
            }

            return emailSend;
        }

        // PUT: api/EmailSends/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailSend(int id, EmailSend emailSend)
        {
            if (id != emailSend.ID)
            {
                return BadRequest();
            }

            _context.Entry(emailSend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailSendExists(id))
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

        // POST: api/EmailSends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmailSend>> PostEmailSend(EmailSend emailSend)
        {
            _context.TBA_EMAILSEND.Add(emailSend);
            await _context.SaveChangesAsync();

            var titleDynamic = emailSend.TITLE != null ? emailSend.TITLE : "Título";
            var contentDynamic = emailSend.EMAILCONTENT != null ? emailSend.EMAILCONTENT : "Mail de prueba";

            var message = new Message(new string[] { "afittipaldi@grupoveraz.com.ar" }, titleDynamic!, contentDynamic!);
            await _emailSender.SendEmailAsync(message);

            return CreatedAtAction("GetEmailSend", new { id = emailSend.ID }, emailSend);
        }

        // DELETE: api/EmailSends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmailSend(int id)
        {
            var emailSend = await _context.TBA_EMAILSEND.FindAsync(id);
            if (emailSend == null)
            {
                return NotFound();
            }

            _context.TBA_EMAILSEND.Remove(emailSend);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailSendExists(int id)
        {
            return _context.TBA_EMAILSEND.Any(e => e.ID == id);
        }
    }
}
