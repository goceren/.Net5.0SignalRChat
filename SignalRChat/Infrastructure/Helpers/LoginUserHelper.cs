using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SignalRChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Infrastructure.Helpers
{
    public class LoginUserHelper
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }

        public static UserModel GetLoginUser()
        {
            var value = httpContextAccessor.HttpContext.Session.GetString("IdentitySession");
            return value == null ? null : JsonConvert.DeserializeObject<UserModel>(value);
        }
    }
}
