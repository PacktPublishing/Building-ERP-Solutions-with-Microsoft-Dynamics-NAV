using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceWebRoleNAV.Classes;

namespace WCFServiceWebRoleNAV
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INAVService
    {
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getShipments?instance={NAVInstanceName}&date={shipmentDateFilter}")]
        List<SalesShipment> GetShipments(string NAVInstanceName, string shipmentDateFilter); //Date format: YYYY-MM-DD
    }

}
