using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailSenderApi.Models;

namespace EmailSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly MailContext _context;

        public MailsController(MailContext context)
        {
            _context = context;
        }

        // GET: api/Mails
        [HttpGet]
        public IEnumerable<Mail> GetMails()
        {
            return _context.Mails;
        }

        // GET: api/Mails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mail = await _context.Mails.FindAsync(id);

            if (mail == null)
            {
                return NotFound();
            }

            return Ok(mail);
        }

        // PUT: api/Mails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMail([FromRoute] int id, [FromBody] Mail mail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mail.ID)
            {
                return BadRequest();
            }

            _context.Entry(mail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(id))
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

        // POST: api/Mails
        [HttpPost]
        public async Task<IActionResult> PostMail([FromBody] Mail mail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mails.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMail", new { id = mail.ID }, mail);
        }

        // DELETE: api/Mails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();

            return Ok(mail);
        }

        private bool MailExists(int id)
        {
            return _context.Mails.Any(e => e.ID == id);
        }
    }
}