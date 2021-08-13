using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SignalRChat.Entity.ComplexTypes;
using System;

namespace SignalRChat.Business.Helper
{
    public class SessionHelperManager : ISessionHelperService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionHelperManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetSession(CtIdentityUser identity)
        {
            try
            {
                //if (GetSession() == null)
                _httpContextAccessor.HttpContext.Session.SetString("IdentitySession", JsonConvert.SerializeObject(identity));
            }
            catch (System.Exception )
            {

            }
        }
        public void ClearSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("IdentitySession");
        }

        public CtIdentityUser GetSession()
        {
            try
            {
                var value = _httpContextAccessor.HttpContext.Session.GetString("IdentitySession");
                return value == null ? null : JsonConvert.DeserializeObject<CtIdentityUser>(value);

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
