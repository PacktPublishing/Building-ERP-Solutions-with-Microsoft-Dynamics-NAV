using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplicationNAV.NAVWS;
using ConsoleApplicationNAV.NAVWS_SalesLines;

namespace ConsoleApplicationNAV
{
    class Program
    {
        static void Main(string[] args)
        {
            string OperationType;
            //If startup parameters are different from one, write the application syntax on screen and exit
            if (args.Length != 1)
            {
                Console.WriteLine(" Usage:");
                Console.WriteLine(" ConsoleApplicationNAV <OperationType>");
                Console.WriteLine(" ------ ");
                Console.WriteLine(" OperationType:");
                Console.WriteLine(" READ: reads NAV Sales Orders");
                Console.WriteLine(" CREATE: create a new Sales Order on NAV");
                Console.WriteLine(" ------ ");
                return;
            }


            Console.WriteLine("Starting execution...");

            //Reading the Operatyon Type parameter
            OperationType = args[0].ToUpper();          

            switch(OperationType)
            {
                case "READ":
                    ReadNAVSalesOrders();
                    break;
                case "CREATE":
                    CreateNAVSalesOrder();
                    break;
                default:
                    Console.WriteLine("Wrong parameter!");
                    break;
                    
            }
        }

        private static void ReadNAVSalesOrders()
        {
            //Here we have to call our NAV web service for reading Sales Orders

            //Web Service instantiation
            SalesOrder_Service ws = new SalesOrder_Service();
            //ws.Url = "http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrder";
            ws.Url = Properties.Settings.Default.NAVWSURL;
            ws.UseDefaultCredentials = true;

            //Setting filters on the table
            List<SalesOrder_Filter> filterArray = new List<SalesOrder_Filter>();
            SalesOrder_Filter filter = new SalesOrder_Filter();
            filter.Field = SalesOrder_Fields.Sell_to_Customer_No;
            filter.Criteria = "10000";
            filterArray.Add(filter);

            //Reading sales orders
            //SalesOrder[] orders = ws.ReadMultiple(filterArray.ToArray(), null, 100);
            List<SalesOrder> orderList = ws.ReadMultiple(filterArray.ToArray(), null, 0).ToList();

            //Printing the results
            if (orderList!=null)
            {
                foreach(SalesOrder order in orderList)
                {
                    Console.WriteLine("Order No.: " + order.No);
                    Console.WriteLine("Order Date: " + order.Order_Date);
                    Console.WriteLine("----------------");                
                }
                //Waiting user input to terminate
                Console.ReadKey();
            }
        }

        private static void CreateNAVSalesOrder()
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
            order.Sell_to_Customer_No = "10000";
            order.Order_Date = DateTime.Now;
            //order.Activity_Code = "123458";

            //Create the Sales Lines array and initialize the lines
            order.SalesLines = new Sales_Order_Line[2];
            for (int i=0; i<2; i++)
            {
                order.SalesLines[i] = new Sales_Order_Line();
            }

            ws.Update(ref order);

            //List<Sales_Order_Line> lines = new List<Sales_Order_Line>();
            
            //First line
            //Sales_Order_Line line = new Sales_Order_Line();
            Sales_Order_Line line = order.SalesLines[0];
            line.Type = NAVWS.Type.Item;
            line.No = "1000";
            line.Quantity = 5;

            //Add the line to the order lines collection
            //lines.Add(line);

            //Second line
            //line = new Sales_Order_Line();
            line = order.SalesLines[1];
            line.Type = NAVWS.Type.Item;
            line.No = "1001";
            line.Quantity = 10;
            
            //Add the line to the order lines collection
            //lines.Add(line);

            //Add the lines to the order
            //order.SalesLines = lines.ToArray();

            //Update the order lines with all the informations
            ws.Update(ref order);

            Console.WriteLine("Order {0} created successfully.", order.No);
        }

        private static void DeleteSalesOrder(string SalesOrderNo)
        {
            //Web Service instantiation
            SalesOrder_Service ws = new SalesOrder_Service();
            //ws.Url = "http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrder";
            ws.Url = Properties.Settings.Default.NAVWSURL;
            ws.UseDefaultCredentials = true;

            //Read the Sales Order
            SalesOrder so = ws.Read(SalesOrderNo);

            //delete the Sales Order
            ws.Delete(so.Key);

            ////delete ALL the lines
            //foreach (Sales_Order_Line line in so.SalesLines)
            //{
            //    ws.Delete_SalesLines(line.Key);
            //}

            ////Delete a specific order line
            //int lineToDelete = 10000;
            //foreach (Sales_Order_Line line in so.SalesLines)
            //{
            //    if (line.Line_No == lineToDelete)
            //    {
            //        ws.Delete_SalesLines(line.Key);
            //    }
            //}

        }

        private static void DeleteSalesOrderLine(string SalesOrderNo, int LineNo)
        {
            //Web Service instantiation
            SalesOrder_Service ws = new SalesOrder_Service();
            //ws.Url = "http://192.6.1.37:7047/DynamicsNAV90/WS/CRONUS%20Italia%20S.p.A./Page/SalesOrder";
            ws.Url = Properties.Settings.Default.NAVWSURL;
            ws.UseDefaultCredentials = true;

            //Read the Sales Order
            SalesOrder so = ws.Read(SalesOrderNo);            

            //Delete a specific order line
            
            foreach (Sales_Order_Line line in so.SalesLines)
            {
                if (line.Line_No == LineNo)
                {
                    ws.Delete_SalesLines(line.Key);
                }
            }

        }

        private static void DeleteSalesOrderLinePage46(string SalesOrderNo, int LineNo)
        {
            //Web Service instantiation
            SalesOrderLInes_Service ws = new SalesOrderLInes_Service();
            ws.Url = Properties.Settings.Default.ConsoleApplicationNAV_NAVWS_SalesLines_SalesOrderLInes_Service;
            ws.UseDefaultCredentials = true;

            SalesOrderLInes line = ws.Read(SalesOrderNo, LineNo);

            if (ws.Delete(line.Key))
            {
                Console.WriteLine("Line deleted.");
            }
        }

    }
}
