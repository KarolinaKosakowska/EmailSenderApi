using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderApi.Models
{
    public class Reciver
    {
        public int ID { get; set; }
        [Required]
        public string To { get; set; }
    }
}
