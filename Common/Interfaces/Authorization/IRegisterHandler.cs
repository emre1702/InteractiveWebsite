using InteractiveWebsite.Common.WebModels.Authentication;
using System.Threading.Tasks;

namespace InteractiveWebsite.Common.Interfaces.Authorization
{
    public interface IRegisterHandler
    {
        Task<RegisterResult> RegisterInternal(RegisterLoginData data);
    }
}
