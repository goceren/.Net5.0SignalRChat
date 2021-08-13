using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRChat.Core.Utilities;
using SignalRChat.Data.Abstract;
using SignalRChat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public HomeController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateMessage(MessageModel message)
        {
            if (ModelState.IsValid)
            {
                var data = _messageService.CreateMessage(new Data.Model.Message()
                {
                    ReceiverId = message.ReceiverId,
                    SenderId = message.SenderId,
                    State = (byte)Enums.StateEnum.Active,
                    Text = message.Text,
                    CreatedOn = DateTime.Now,
                });
                return Ok();
            }
            return Error();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
