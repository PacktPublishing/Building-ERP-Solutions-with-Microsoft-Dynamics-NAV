using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NAVB2BService.DAL
{
    public class DALPrices
    {
        public decimal GetPrice(string CustomerNo, DateTime PostingDate, string ItemNo, decimal Quantity, string UoM, string CampaignCode)
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

                decimal price = ws.GetSalesPrice(CustomerNo, PostingDate, ItemNo, Quantity, UoM, CampaignCode);

                return price;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public decimal GetDiscount(string CustomerNo, DateTime PostingDate, string ItemNo, decimal Quantity, string UoM, string CampaignCode)
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

                decimal discount = ws.GetSalesDiscount(CustomerNo, PostingDate, ItemNo, Quantity, UoM, CampaignCode);

                return discount;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public decimal GetInventory(string ItemNo)
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

                decimal discount = ws.GetItemInventory(ItemNo);

                return discount;
            }
            catch (Exception)
            {
                return 0;
            }

        }


    }
}