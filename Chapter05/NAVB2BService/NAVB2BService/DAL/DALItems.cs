using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using NAVB2BService.Classi;

namespace NAVB2BService.DAL
{
    public class DALItems
    {
        public List<Item> GetItems(string ModifiedDate)
        {
            string serviceODataURL = ConfigurationManager.AppSettings["NAVODATAUrl"];
            string WS_User = ConfigurationManager.AppSettings["NAV_User"];
            string WS_Pwd = ConfigurationManager.AppSettings["NAV_Pwd"];
            string WS_Domain = ConfigurationManager.AppSettings["NAV_Domain"];
            string Company = ConfigurationManager.AppSettings["Company"];

            string serviceUri = string.Format(serviceODataURL + "/Company('{0}')", Company);

            List<Item> itemListB2B = new List<Item>();

            try
            {
                DataServiceContext context = new DataServiceContext(new Uri(serviceUri));

                NAV_ODATA.NAV theNav = new NAV_ODATA.NAV(new Uri(serviceUri));
                theNav.Credentials = new System.Net.NetworkCredential(WS_User, WS_Pwd, WS_Domain);

                DataServiceQuery<NAV_ODATA.B2BArticoliWeb> q = theNav.CreateQuery<NAV_ODATA.B2BArticoliWeb>("B2BArticoliWeb");

                if (ModifiedDate.Length > 0)
                {
                    //OData Filter Expression ge = greater than or equal to
                    string FilterValue = string.Format("Last_Date_Modified ge datetime'{0}' or Last_Movement_Date ge datetime'{0}'", ModifiedDate);
                    q = q.AddQueryOption("$filter", FilterValue);
                }

                List<NAV_ODATA.B2BArticoliWeb> itemList = q.Execute().ToList();

                foreach (NAV_ODATA.B2BArticoliWeb item in itemList)
                {
                    Item a = new Item();
                    a.No = item.No;
                    a.Description1 = item.Description;
                    a.Description2 = item.Description_2;
                    a.Inventory = item.Inventory;
                    a.Lot = item.Quantità_Lotto;
                    a.UnitOfMeasure = item.Base_Unit_of_Measure;
                    a.ItemType = item.Linea;
                    a.ItemBrand= item.Dimension_Value_Code;
                    a.BrandDescription = item.Name;
                    itemListB2B.Add(a);
                }
            }
            catch (Exception ex)
            {
                string exmsg = ex.Message;
            }

            return itemListB2B;
        }
    }
}