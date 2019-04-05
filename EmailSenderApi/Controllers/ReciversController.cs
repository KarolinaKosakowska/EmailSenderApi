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
    public class ReciversController : ControllerBase
    {
        private readonly MailContext _context;

        public ReciversController(MailContext context)
        {
            _context = context;
        }

        // GET: api/Recivers
        [HttpGet]
        public IEnumerable<Reciver> GetRecivers()
        {
            return _context.Recivers;
        }

        // GET: api/Recivers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReciver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reciver = await _context.Recivers.FindAsync(id);

            if (reciver == null)
            {
                return NotFound();
            }

            return Ok(reciver);
        }

        // PUT: api/Recivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReciver([FromRoute] int id, [FromBody] Reciver reciver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reciver.ID)
            {
                return BadRequest();
            }

            _context.Entry(reciver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciverExists(id))
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

        // POST: api/Recivers
        [HttpPost]
        public async Task<IActionResult> PostReciver([FromBody] Reciver reciver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Recivers.Add(reciver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReciver", new { id = reciver.ID }, reciver);
        }

        // DELETE: api/Recivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReciver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reciver = await _context.Recivers.FindAsync(id);
            if (reciver == null)
            {
                return NotFound();
            }

            _context.Recivers.Remove(reciver);
            await _context.SaveChangesAsync();

            return Ok(reciver);
        }

        private bool ReciverExists(int id)
        {
            return _context.Recivers.Any(e => e.ID == id);
        }
    }
}