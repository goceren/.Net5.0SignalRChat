using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.WebUI.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Messages = new List<MessageModel>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int WrongAttemptCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ChangedOn { get; set; }
        public byte State { get; set; }
        public virtual List<MessageModel> Messages { get; set; }
    }
}
