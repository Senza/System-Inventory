﻿using InventorySystemDataManager.Library.Internal.DataAccess;
using InventorySystemDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemDataManager.Library.DataAccess
{
    public class InventoryData
    {
        public List<InventoryModel> GetInventory() 
        {
            SqlDataAccess sql = new SqlDataAccess();
            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "InvSysData");
            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInventory_Insert", item, "InvSysData");
        }
    }
}
