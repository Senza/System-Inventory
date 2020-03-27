using InvSysUI.Models;
using System.Threading.Tasks;

namespace InvSysUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string Username, string Password);
        Task GetLoggedInUserInfo(string token);
    }
}