using InvSysUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSysUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}