using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmailSenderApi.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace EmailSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly MailContext db;

        public MailsController(MailContext db)
        {
            this.db = db;
        }

        // GET: api/Mails
        [HttpGet]
        public IActionResult GetMails()
        {
            try
            {
                return Ok(db.Mails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // GET: api/Mails/5
        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetMail([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var mail = await db.Mails.FindAsync(id);

        //    if (mail == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(mail);
        //}

        //// PUT: api/Mails/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMail([FromRoute] int id, [FromBody] Mail mail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != mail.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(mail).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Mails
        [HttpPost]
        public IActionResult SendMail( Mail mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var smtpClient = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587, 
                        EnableSsl = true,
                        Credentials = new NetworkCredential(mail.From, "")
                    };

                    using (var message = new MailMessage("sendermail58", mail.To)
                    {
                        Subject = mail.Title,
                        Body = mail.Body
                    })
                    {
                        smtpClient.Send(message);
                    }
                    db.Mails.Add(mail);
                    db.SaveChanges();
                   
                    return CreatedAtAction("Wysłano", new { id = mail.ID }, mail);
                }

                return BadRequest("Sprawdź adresy, proawidłowy wygląda nasępująco: aaa@aaa.aaa");
            }


            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




        //// DELETE: api/Mails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMail([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var mail = await db.Mails.FindAsync(id);
        //    if (mail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Mails.Remove(mail);
        //    await db.SaveChangesAsync();

        //    return Ok(mail);
        //}

        //private bool MailExists(int id)
        //{
        //    return db.Mails.Any(e => e.ID == id);
        //}
        public bool EmailIsValid(object value)
        {
            Regex regex = new Regex(@"^((?:(?:[a-zA-Z0-9_\-\.]+)@(?:(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(?:(?:[a-zA-Z0-9\-]+\.)+))(?:[a-zA-Z]{2,4}|[0-9]{1,3})(?:\]?)(?:\s*;\s*|\s*$))*)$");
            if (!regex.Match(value.ToString()).Success)
            {
                return false;
            }
            return true;
        }
    }
}

