using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InventorySystemDataManager.Library
{
    public class ConfigHelper 
    {
        public static decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out decimal taxRate);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The tax rate is not setup properly");
            }

            return taxRate;
        }
    }
}
