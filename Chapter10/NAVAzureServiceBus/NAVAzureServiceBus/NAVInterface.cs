using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAVAzureServiceBus.Classes;
using NAVAzureServiceBus.NAVSalesOrderWS;

namespace NAVAzureServiceBus
{
    class NAVInterface
    {
        public void CreateNAVSalesOrder(ShopSalesOrder ExternalOrder)
        {
            try
            {
                //Here we have to call our NAV web service for creating a Sales Order
                //Web Service instantiation
                SalesOrder_Service ws = new SalesOrder_Service();
                ws.Url = Properties.Settings.Default.NAVWSURL;
                ws.UseDefaultCredentials = true;

                //Create the Sales Header
                SalesOrder order = new SalesOrder();
                ws.Create(ref order);

                //Here the Sales Order is created and we have the order no.
                
                //Update the Sales Header with details
                order.Sell_to_Customer_No = ExternalOrder.CustomerNo;
                order.Order_Date = ExternalOrder.OrderDate;
                order.Activity_Code = "123458";

                int _rows = 0;
                if (ExternalOrder.Lines != null)
                {
                    _rows = ExternalOrder.Lines.Count();
                }

                if (_rows > 0)
                {
                    //Create the Sales Lines array and initialize the lines
                    order.SalesLines = new Sales_Order_Line[_rows];
                    for (int i = 0; i < _rows; i++)
                    {
                        order.SalesLines[i] = new Sales_Order_Line();
                    }
                }

                ws.Update(ref order);

                //Loads the data into the Lines
                if (_rows > 0)
                {
                    int rowindex = 0;
                    foreach(ShopSalesOrderLine _shopOrderLine in ExternalOrder.Lines)
                    {
                        Sales_Order_Line line = order.SalesLines[rowindex];
                        line.Type = NAVSalesOrderWS.Type.Item;
                        line.No = _shopOrderLine.ItemNo;
                        line.Quantity = _shopOrderLine.Quantity;
                        rowindex++;
                    }

                    //Update the order lines with all the informations
                    ws.Update(ref order);
                }
                
                Console.WriteLine("Order {0} created successfully.", order.No);
            }
            catch(Exception)
            {
                //Handle exceptions here...
            }
        }

    }
}
