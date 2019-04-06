using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSenderApi.Models
{
    public class Mail
    {
        public int ID { get; set; }
        [Required]
        //public virtual Reciver Reciver { get; set; }
        //[Required]

        public string To { get; set; }
        [Required]
        public string From { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Body { get; set; }
    }
}
