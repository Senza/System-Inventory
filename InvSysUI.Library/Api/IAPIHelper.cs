using InvSysUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvSysUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        void LogOffUser();
        Task<AuthenticatedUser> Authenticate(string Username, string Password);
        Task GetLoggedInUserInfo(string token);
    }
}