using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.WebUI.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Users = new List<UserModel>();
        }
        public List<UserModel> Users { get; set; }
    }
}
