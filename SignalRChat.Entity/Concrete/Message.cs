using SignalRChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Entity.Concrete
{
    public partial class Message : IEntity
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ChangedOn { get; set; }
        public byte State { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
