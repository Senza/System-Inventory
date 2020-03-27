using InvSysUI.Models;
using System.Threading.Tasks;

namespace InvSysUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string Username, string Password);
    }
}