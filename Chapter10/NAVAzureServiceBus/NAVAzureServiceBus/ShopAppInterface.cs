using NAVAzureServiceBus.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVAzureServiceBus
{
    class ShopAppInterface
    {
        public ShopSalesOrder GetNAVOrder()
        {
            //Retrieves order from the shop center application (specific code goes here...
            ShopSalesOrder order = new ShopSalesOrder();
            order.OrderNo = "OV1";
            order.OrderDate = DateTime.Now;
            order.CustomerNo = "C0001";
            List<ShopSalesOrderLine> lines = new List<ShopSalesOrderLine>();
            ShopSalesOrderLine line = new ShopSalesOrderLine();
            line.RowNo = 1;
            line.ItemNo = "ITEM1";
            line.Quantity = 5;
            lines.Add(line);
            line = new ShopSalesOrderLine();
            line.RowNo = 2;
            line.ItemNo = "ITEM2";
            line.Quantity = 13;
            lines.Add(line);

            order.Lines = lines;

            return order;
        }
    }
}
