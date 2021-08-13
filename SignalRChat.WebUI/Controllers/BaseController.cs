using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalRChat.Business.Helper;
using SignalRChat.Data.Abstract;
using SignalRChat.Entity.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public CtIdentityUser LoginUser { get; set; }


        private readonly IUserService _userService;
        private readonly ISessionHelperService _sessionHelper;

        public BaseController(IUserService userService, ISessionHelperService sessionHelper)
        {
            _userService = userService;
            _sessionHelper = sessionHelper;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var currentUser = _sessionHelper.GetSession();
            if (currentUser == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
            else
            {
                LoginUser = currentUser;
            }


            base.OnActionExecuting(filterContext);
        }

    }
}
