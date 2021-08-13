using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.WebUI.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }


        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
        public byte State { get; set; }

        public UserModel Sender { get; set; }
        public UserModel Receiver { get; set; }
    }
}
