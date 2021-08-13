using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRChat.Business.Abstract;
using SignalRChat.Business.Helper;
using SignalRChat.Core.Utilities;
using SignalRChat.Data.Abstract;
using SignalRChat.Entity.Concrete;
using SignalRChat.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService, IUserService userService, ISessionHelperService sessionHelper) : base(userService, sessionHelper)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            var users = _userService.GetList(i => i.State == (byte)Enums.StateEnum.Active && i.Id != LoginUser.Id);
            if (users.Status.Status == Enums.StatusEnum.Successful)
            {
                model.Users = users.Entity.Select(i => new UserModel() {
                    Id = i.Id,
                    Username = i.Username,
                    CreatedOn = i.CreatedOn,
                    Email = i.Email,
                    Phone = i.Phone,
                    State = i.State,
                    ChangedOn = i.ChangedOn
                }).ToList();
            }
            return View(model);
        }

        public async Task<IActionResult> CreateMessage(MessageModel message)
        {
            if (ModelState.IsValid)
            {
                var data = _messageService.Add(new Message()
                {
                    ReceiverId = message.ReceiverId,
                    SenderId = LoginUser.Id,
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
