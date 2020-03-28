using InventorySystemDataManager.Library.DataAccess;
using InventorySystemDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventorySystemDataManager.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
       
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetPrducts();
        }

    }
}
