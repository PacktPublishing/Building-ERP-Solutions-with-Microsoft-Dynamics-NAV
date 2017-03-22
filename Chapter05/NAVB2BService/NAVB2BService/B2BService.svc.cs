using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using NAVB2BService.Classi;
using NAVB2BService.DAL;
namespace RestService
{
    public class B2BService : IB2BService
    {
       

        //Chiamata: http://localhost:35798/B2BService.svc/getArticoliXML

        #region ITEMS

        public List<Item> GetItemsXML()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALItems DAL = new DALItems();
            return DAL.GetItems("");
        }

        public List<Item> GetItemsJSON()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALItems DAL = new DALItems();
            return DAL.GetItems("");
        }

        public List<Item> GetItemsXML(string ModifiedDate)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALItems DAL = new DALItems();
            return DAL.GetItems(ModifiedDate);
        }

        public List<Item> GetItemsJSON(string ModifiedDate)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                //throw new HttpException(401, "Unauthorized access"); //No HttpException perchè viene convertita in errore 400
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALItems DAL = new DALItems();
            return DAL.GetItems(ModifiedDate);
        }

        #endregion

        #region CUSTOMERS

        public List<Customer> GetCustomersXML()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALCustomers DAL = new DALCustomers();
            return DAL.GetCustomers();
        }

        public List<Customer> GetCustomersJSON()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALCustomers DAL = new DALCustomers();
            return DAL.GetCustomers();
        }

        #endregion

        #region SHIPMENT ADDRESSES

        public List<ShipmentAddress> getShipmentAddressesXML()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                //throw new HttpException(401, "Unauthorized access"); //No HttpException perchè viene convertita in errore 400
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALShipmentAddresses DAL = new DALShipmentAddresses();
            return DAL.GetShipmentAddresses();
        }

        public List<ShipmentAddress> getShipmentAddressesJSON()
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DALShipmentAddresses DAL = new DALShipmentAddresses();
            return DAL.GetShipmentAddresses();
        }

        #endregion

        #region PRICES AND DISCOUNTS
        

        //URL TEST: http://localhost:35798/B2BService.svc/getPrezzoXML?cliente=05000003&data=13-11-2014&art=01001&qty=5
        public decimal GetSalesPriceXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DALPrices DAL = new DALPrices();
            decimal _price = DAL.GetPrice(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return _price;
        }

        public decimal GetSalesDiscountXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                //throw new HttpException(401, "Unauthorized access"); //No HttpException perchè viene convertita in errore 400
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DALPrices DAL = new DALPrices();
            decimal _discount = DAL.GetDiscount(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return _discount;
        }

        public decimal GetSalesPriceJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                //throw new HttpException(401, "Unauthorized access"); //No HttpException perchè viene convertita in errore 400
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DALPrices DAL = new DALPrices();
            decimal _price = DAL.GetPrice(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return _price;
        }

        public decimal GetSalesDiscountJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                //throw new HttpException(401, "Unauthorized access"); //No HttpException perchè viene convertita in errore 400
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DALPrices DAL = new DALPrices();
            decimal _discount = DAL.GetDiscount(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return _discount;
        }

        public ItemDetail GetItemDetailXML(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            ItemDetail DET = new ItemDetail();
            DALPrices DAL = new DALPrices();
            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DET.ItemNo = ItemNo;
            DET.Price = DAL.GetPrice(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            DET.Discount = DAL.GetDiscount(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return DET;
        }

        public ItemDetail GetItemDetailJSON(string CustomerNo, string OrderDate, string ItemNo, decimal Quantity)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            ItemDetail DET = new ItemDetail();
            DALPrices DAL = new DALPrices();
            DateTime _dtOrdine = Convert.ToDateTime(OrderDate);
            DET.ItemNo = ItemNo;
            DET.Price = DAL.GetPrice(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            DET.Discount = DAL.GetDiscount(CustomerNo, _dtOrdine, ItemNo, Quantity, "PZ", "");
            return DET;
        }

        #endregion

        #region SALES ORDERS

        public string InsertOrderXML(Order order)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            try
            {
                DALOrders DAL = new DALOrders();
                string result = DAL.InsertOrder(order);
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertOrderJSON(Order order)
        {
            if (!CheckBasicAuthentication())
            {
                //Autenticazione non riuscita
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            try
            {
                DALOrders DAL = new DALOrders();
                string result = DAL.InsertOrder(order);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

       


        //Check WS Authentication in HTTP Request Header
        private Boolean CheckBasicAuthentication()
        {
            //FOR TESTING: ALWAYS AUTHORIZED
            return true;

            //try
            //{
            //    string userKEY = ConfigurationManager.AppSettings["WS_User"];
            //    string pwdKEY = ConfigurationManager.AppSettings["WS_Pwd"];
            //    string auth = WebOperationContext.Current.IncomingRequest.Headers[HttpRequestHeader.Authorization];
            //    if (auth != null)
            //    {
            //        if (auth.StartsWith("Basic "))
            //        {
            //            string cred = Encoding.UTF8.GetString(Convert.FromBase64String(auth.Substring("Basic ".Length)));
            //            string[] parts = cred.Split(':');
            //            string userName = parts[0];
            //            string password = parts[1];
            //            if ((userName == userKEY) && (password == pwdKEY))
            //            {
            //                return true;
            //            }
            //            //return string.Format("User: {0}, password: {1}", userName, password);
            //        }
            //    }

            //    return false;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }


    }
}