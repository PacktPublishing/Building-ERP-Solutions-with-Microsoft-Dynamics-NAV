using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using NAVB2BService.Classi;


//NOTA: OData NAV Service: alzare il limite dei record ritornati come set dati (default = 1000) in CustomSettings.config del servizio NAV
//<!--Maximum permitted page size of a Data Services response, in number of entities-->
//<add key="ODataServicesMaxPageSize" value="1000" />

namespace RestService
{
    
    [ServiceContract]
    public interface IB2BService
    {        
        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Xml,BodyStyle = WebMessageBodyStyle.Wrapped,UriTemplate = "getItemsXML")]
        List<Item> GetItemsXML();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getItemsJSON")]
        List<Item> GetItemsJSON();

        [OperationContract(Name = "GetItemsXMLbyDate")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getItemsXML?date={ModifiedDate}")]
        List<Item> GetItemsXML(string ModifiedDate); //Format YYYY-MM-DD

        [OperationContract(Name = "GetItemsJSONbyDate")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getItemsJSON?date={ModifiedDate}")]
        List<Item> GetItemsJSON(string ModifiedDate);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getCustomersXML")]
        List<Customer> GetCustomersXML();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getCustomersJSON")]
        List<Customer> GetCustomersJSON();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getShipmentAddressesXML")]
        List<ShipmentAddress> getShipmentAddressesXML();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getShipmentAddressesJSON")]
        List<ShipmentAddress> getShipmentAddressesJSON();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getPriceXML?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        decimal GetSalesPriceXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getPriceJSON?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        decimal GetSalesPriceJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getDiscountXML?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        decimal GetSalesDiscountXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getDiscountJSON?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        decimal GetSalesDiscountJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA        

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getItemDetailXML?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        ItemDetail GetItemDetailXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA      

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "getItemDetailJSON?cust={CustomerNo}&date={OrderDate}&item={ItemNo}&qty={Quantity}")]
        ItemDetail GetItemDetailJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity);
        //La data va passata nel formato GG-MM-AAAA        

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/insertOrderXML")]
        string InsertOrderXML(Order order);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/insertOrderJSON")]
        string InsertOrderJSON(Order order);

        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/updateB2BPasswordXML")]
        //string UpdateB2BPasswordXML(B2BPassword password);

        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/updateB2BPasswordJSON")]
        //string UpdateB2BPasswordJSON(B2BPassword password);

    }
}