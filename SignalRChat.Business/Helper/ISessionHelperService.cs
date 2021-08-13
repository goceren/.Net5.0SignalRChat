
using SignalRChat.Entity.ComplexTypes;

namespace SignalRChat.Business.Helper
{
    public interface ISessionHelperService
    {
        void SetSession(CtIdentityUser identity);
        void ClearSession();
        CtIdentityUser GetSession();
    }
}
