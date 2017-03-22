using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using NAVB2BService.Classi;

namespace NAVB2BService.DAL
{
    public class DALShipmentAddresses
    {
        public List<ShipmentAddress> GetShipmentAddresses()
        {
            string serviceODataURL = ConfigurationManager.AppSettings["NAVODATAUrl"];
            string WS_User = ConfigurationManager.AppSettings["NAV_User"];
            string WS_Pwd = ConfigurationManager.AppSettings["NAV_Pwd"];
            string WS_Domain = ConfigurationManager.AppSettings["NAV_Domain"];
            string Company = ConfigurationManager.AppSettings["Company"];

            string serviceUri = string.Format(serviceODataURL + "/Company('{0}')", Company);

            List<ShipmentAddress> indListB2B = new List<ShipmentAddress>();

            try
            {
                DataServiceContext context = new DataServiceContext(new Uri(serviceUri));

                NAV_ODATA.NAV theNav = new NAV_ODATA.NAV(new Uri(serviceUri));
                theNav.Credentials = new System.Net.NetworkCredential(WS_User, WS_Pwd, WS_Domain);

                DataServiceQuery<NAV_ODATA.B2BShipAddress> q = theNav.CreateQuery<NAV_ODATA.B2BShipAddress>("B2BShipAddress");

                List<NAV_ODATA.B2BShipAddress> addrList = q.Execute().ToList();

                foreach (NAV_ODATA.B2BShipAddress addr in addrList)
                {
                    ShipmentAddress ind = new ShipmentAddress();
                    ind.CustomerNo = addr.Customer_No;
                    ind.Code = addr.Code;
                    ind.Name = addr.Name;
                    ind.Address = addr.Address;
                    ind.City = addr.City;
                    ind.County = addr.County;
                    ind.Country = addr.Country_Region_Code;
                    ind.Default = addr.Default_Shipment;

                    indListB2B.Add(ind);
                }
            }
            catch (Exception)
            {
            }

            return indListB2B;
        }
    }
}