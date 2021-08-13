using SignalRChat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Entity.Concrete
{
    public partial class User : IEntity
    {
        public User()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int WrongAttemptCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ChangedOn { get; set; }
        public byte State { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
