using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NAVB2BService.Classi;

namespace NAVB2BService.DAL
{
    public class DALOrders
    {
        
        public string InsertOrder(Order order)
        {
            string serviceSOAPURL = ConfigurationManager.AppSettings["NAVSOAPUrl"];
            string WS_User = ConfigurationManager.AppSettings["NAV_User"];
            string WS_Pwd = ConfigurationManager.AppSettings["NAV_Pwd"];
            string WS_Domain = ConfigurationManager.AppSettings["NAV_Domain"];
            string Company = ConfigurationManager.AppSettings["Company"];

            string serviceUri = string.Format(serviceSOAPURL, Company);
            try
            {
                B2BManagement.B2BManagement ws = new B2BManagement.B2BManagement();
                ws.Url = serviceUri;
                ws.Credentials = new System.Net.NetworkCredential(WS_User, WS_Pwd, WS_Domain);

                string result = ws.InsertOrderB2B(order.OrderNo, order.LineNo, order.CustomerNo, order.OrderDate, order.ShipmentAddressCode, order.ItemNo, order.Quantity, order.Note);

                return result;
            }
            catch (Exception ex)
            {
                return "KO: " + ex.Message;
            }            

        }
    }
}