using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorEmailManager.Models
{
    public class EmailDraft
    {
        public EmailDraft()
        {
            Sender = new Sender();
        }

        public Sender Sender { get; set; }

        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }
        [Required]
        [MaxLength(500)]
        public string MessageText { get; set; }

        public IList<string> Recipients { get; set; }
    }
}
