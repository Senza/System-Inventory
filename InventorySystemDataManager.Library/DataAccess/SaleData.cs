using InventorySystemDataManager.Library.Internal.DataAccess;
using InventorySystemDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemDataManager.Library.DataAccess
{
    public class SaleData
    {
        

        public void SaveSale(SaleModel saleInfo, string cashierId) 
        {
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                    
                };

               var ProductInfo = products.GetProductById(detail.ProductId);

                if(ProductInfo == null) 
                {
                    throw new Exception($"The product Id of {detail.ProductId} could not be found in the database.");
                }

                detail.PurchasePrice = (ProductInfo.RetailPrice * detail.Quantity);

                if(ProductInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel 
            { 
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            using (SqlDataAccess sql = new SqlDataAccess()) 
            {
                try
                {
                    sql.StartTranscation("InvSysData");
                    sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                    sale.Id = sql.LoadDataInTransaction<int, dynamic>("spSale_Lookup",
                    new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;
                        sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                    }

                    sql.CommitTransaction();
                }
                catch
                {

                    sql.RollbackTransaction();
                    throw;
                }

            }




            //public List<ProductModel> GetPrducts()
            //{
            //    SqlDataAccess sql = new SqlDataAccess();


            //    var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "InvSysData");

            //    return output;
            //}

        }
    }
}
