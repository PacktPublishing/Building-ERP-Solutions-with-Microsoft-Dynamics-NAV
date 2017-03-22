using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using WCFServiceWebRoleNAV.Classes;

namespace WCFServiceWebRoleNAV.DataAccessLayer
{
    public class DataAccessLayer
    {
        public List<SalesShipment> GetNAVShipments(string NAVInstanceName, string shipmentDateFilter)
        {
            try
            {
                string URL = Properties.Settings.Default[NAVInstanceName].ToString();
                string WS_User = Properties.Settings.Default[NAVInstanceName + "_User"].ToString();
                string WS_Pwd = Properties.Settings.Default[NAVInstanceName + "_Pwd"].ToString();
                string WS_Domain = Properties.Settings.Default[NAVInstanceName + "_Domain"].ToString();

                DataServiceContext context = new DataServiceContext(new Uri(URL));

                NAVODATAWS.NAV NAV = new NAVODATAWS.NAV(new Uri(URL));
                NAV.Credentials = new System.Net.NetworkCredential(WS_User, WS_Pwd, WS_Domain);

                DataServiceQuery<NAVODATAWS.ItemShipments> q = NAV.CreateQuery<NAVODATAWS.ItemShipments>("ItemShipments");

                if (shipmentDateFilter != null)
                {
                    string FilterValue = string.Format("Shipment_Date ge datetime'{0}'", shipmentDateFilter);
                    q = q.AddQueryOption("$filter", FilterValue);
                }

                List<NAVODATAWS.ItemShipments> list = q.Execute().ToList();

                List<SalesShipment> sslist = new List<SalesShipment>();

                foreach (NAVODATAWS.ItemShipments shpt in list)
                {
                    SalesShipment ss = new SalesShipment();
                    ss.No = shpt.No;
                    ss.CustomerNo = shpt.Sell_to_Customer_No;
                    ss.ItemNo = shpt.ItemNo;
                    ss.Description = shpt.Description;
                    ss.Description2 = shpt.Description_2;
                    ss.UoM = shpt.Unit_of_Measure;
                    ss.Quantity = shpt.Quantity;
                    ss.ShipmentDate = shpt.Shipment_Date;
                    sslist.Add(ss);
                }

                return sslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}