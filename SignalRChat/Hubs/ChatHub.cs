using Microsoft.AspNetCore.SignalR;
using SignalRChat.Core.Models;
using SignalRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageModel message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
