using InventorySystemDataManager.Library.Internal.DataAccess;
using InventorySystemDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemDataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetPrducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

           
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "InvSysData");

            return output;
        }

        public ProductModel GetProductById(int productId) 
        {

            SqlDataAccess sql = new SqlDataAccess();


            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new {Id = productId }, "InvSysData").FirstOrDefault();

            return output;

        }
    }
}
