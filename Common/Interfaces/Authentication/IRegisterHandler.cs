using InteractiveWebsite.Common.Classes.Authentication;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Authentication
{
    public interface IRegisterHandler
    {
        Task<RegisterResult> RegisterInternal(RegisterLoginData data);
    }
}
