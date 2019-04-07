using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderApi.Models
{
    public class MailContext: DbContext
    {
        public MailContext(DbContextOptions<MailContext> options): base(options)
        {

        }
        public DbSet<Mail> Mails { get; set; }

    }
}
