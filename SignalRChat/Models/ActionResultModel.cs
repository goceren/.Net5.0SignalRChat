using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Models
{
    public class ActionResultModel
    {
        public string ActionData { get; set; }
        public string ActionStatus { get; set; }
        public string ActionMessage { get; set; }
        public string ActionTitle { get; set; }
    }
}
