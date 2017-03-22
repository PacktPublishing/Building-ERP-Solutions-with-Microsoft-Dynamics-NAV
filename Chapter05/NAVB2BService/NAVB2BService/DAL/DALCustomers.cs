using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using NAVB2BService.Classi;

namespace NAVB2BService.DAL
{
    public class DALCustomers
    {
        public List<Customer> GetCustomers()
        {
            string serviceODataURL = ConfigurationManager.AppSettings["NAVODATAUrl"];
            string WS_User = ConfigurationManager.AppSettings["NAV_User"];
            string WS_Pwd = ConfigurationManager.AppSettings["NAV_Pwd"];
            string WS_Domain = ConfigurationManager.AppSettings["NAV_Domain"];
            string Company = ConfigurationManager.AppSettings["Company"];
            //OData URI creation
            string serviceUri = string.Format(serviceODataURL + "/Company('{0}')", Company);

            List<Customer> custListB2B = new List<Customer>();

            try
            {
                DataServiceContext context = new DataServiceContext(new Uri(serviceUri));
                //Web service initialization
                NAV_ODATA.NAV theNav = new NAV_ODATA.NAV(new Uri(serviceUri));
                //User impersonation
                theNav.Credentials = new System.Net.NetworkCredential(WS_User, WS_Pwd, WS_Domain);
                //Calls the OData WS (NAV Query)
                DataServiceQuery<NAV_ODATA.B2BClientiWeb> q = theNav.CreateQuery<NAV_ODATA.B2BClientiWeb>("B2BClientiWeb");

                List<NAV_ODATA.B2BClientiWeb> custList = q.Execute().ToList();

                foreach (NAV_ODATA.B2BClientiWeb cust in custList)
                {
                    Customer c = new Customer();
                    c.No = cust.No;                    
                    c.Name = cust.Name;
                    c.Address = cust.Address;
                    c.City = cust.City;
                    c.CAP = cust.Post_Code;
                    c.Country = cust.Country_Region_Code;
                    c.County = cust.County;
                    c.FiscalCode = cust.Fiscal_Code;
                    c.VATNo = cust.VAT_Registration_No;
                    c.EmailEcommerce = cust.Email_Ecommerce;
                    c.Active = cust.ActivadoWeb;                    
                    custListB2B.Add(c);
                }
            }
            catch (Exception)
            {
            }

            return custListB2B;
        }
    }
}