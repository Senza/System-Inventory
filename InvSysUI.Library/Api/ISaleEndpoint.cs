using InvSysUI.Library.Models;
using System.Threading.Tasks;

namespace InvSysUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}