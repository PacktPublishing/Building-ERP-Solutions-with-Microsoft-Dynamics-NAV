using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceWebRoleNAV.Classes;
using WCFServiceWebRoleNAV.DataAccessLayer;

namespace WCFServiceWebRoleNAV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NAVService : INAVService
    {
        
        public List<SalesShipment> GetShipments(string NAVInstanceName, string shipmentDateFilter)
        { 
            try
            {
                DataAccessLayer.DataAccessLayer DAL = new DataAccessLayer.DataAccessLayer();
                List<SalesShipment>  list = DAL.GetNAVShipments(NAVInstanceName, shipmentDateFilter);
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



    }
}
