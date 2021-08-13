using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRChat.Core.Utilities;
using SignalRChat.Data.Abstract;
using SignalRChat.Identity;
using SignalRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionHelperService _sessionHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(
            IHttpContextAccessor httpContextAccessor,
            IUserService userService, ISessionHelperService sessionHelper)
        {
            _userService = userService;
            _sessionHelper = sessionHelper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public JsonResult Login(LoginViewModel model)
        {
            if (model != null)
            {
                var checkUser = _userService.LoginUser(model.UserName, model.Password);

                if (checkUser.Status.Status == Enums.StatusEnum.Successful)
                {
                    var returnUrl = "/Home/Index";
                    return Json(
                        new {
                            ActionStatus = Enums.StatusEnum.Successful.ToString(),
                            ActionMessage = "Giriş Başarılı! Yönlendiriliyorsunuz...",
                            ReturnUrl = returnUrl
                        });
                }
                else
                {
                    return Json(new ActionResultModel()
                    {
                        ActionStatus = Enums.StatusEnum.Error.ToString(),
                        ActionMessage = "E-Mail Adresi veya Şifre hiçbir hesapla eşleşmiyor. "
                    });
                }
            }
            else
            {
                return Json(new ActionResultModel() { ActionStatus = Enums.StatusEnum.Error.ToString(), ActionMessage = "Kullanıcı Adınız veya Parolanız Yanlış!" });
            }
        }


        public IActionResult Logout()
        {
            _sessionHelper.ClearSession();
            return RedirectToAction("Login", "Account");
        }
    }
}
