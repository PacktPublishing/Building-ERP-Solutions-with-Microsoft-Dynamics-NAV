using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TESTApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertOrder_Click(object sender, EventArgs e)
        {
            //Create the Order object to insert
            B2B.Ordine ordine = new B2B.Ordine();
            ordine.NrOrdine = "WEB01";
            ordine.NrRiga = 1;
            ordine.CodiceCliente = "05000003";
            ordine.DataOrdine = DateTime.Today;
            ordine.CodiceArticolo = "01001";
            ordine.CodiceIndirizzoDestinazione = "";
            ordine.Quantita = 10;
            ordine.Note = "test EID";
            try
            {
                string uri = "http://localhost:35798/B2BService.svc/insertOrderJSON";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                //Basic Authentication settings (username:password)
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("xxx" + ":" + "xxx"));
                httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(ordine);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message + " - Dettagli: " + ex.InnerException);
            }

        }

        private void btnB2B_Click(object sender, EventArgs e)
        {
            B2B.B2BPassword pwd = new B2B.B2BPassword();
            pwd.Utente = "05000003";
            pwd.MD5HiddenPricePassword = "662a2e96162905620397b19c9d249781";
            pwd.MD5Password = "4013b092d26f812e3440acdfe5301ea7";
            try
            {
                string uri = "http://localhost:35798/B2BService.svc/updateB2BPasswordJSON";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                //Basic Authentication settings (username:password)
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("xxx" + ":" + "xxx"));
                httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(pwd);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message + " - Dettagli: " + ex.InnerException);
            }
        }

        private void btnGetPrice_Click(object sender, EventArgs e)
        {
            try
            {                
                string uri = "http://localhost:35798/B2BService.svc/getPrezzoArticoloJSON?cliente=05001041&data=2016-05-30&art=01001&qty=1";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                //Basic Authentication settings (user:password)
                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("xxx" + ":" + "xxx"));
                httpWebRequest.Headers.Add("Authorization", "Basic " + svcCredentials);


                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = streamReader.ReadToEnd();
                    MessageBox.Show("Risposta: " + response);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message + " - Dettagli: " + ex.InnerException);
            }
        }

        private void btnGetPriceNAV_Click(object sender, EventArgs e)
        {
            string CustomerNo = "05000504";
            DateTime PostingDate= new DateTime(2016,4,1);
            string ItemNo = "06161";
            decimal Quantity = 1;
            string UoM="PZ";
            string CampaignCode="";

            try
            {
                B2BManagement.B2BManagement ws = new B2BManagement.B2BManagement();
                ws.Url = "http://srv-wk12.febiitalia.local:7047/DynamicsNAV80/WS/Febi/Codeunit/B2BManagement";
                //ws.Url = "http://77.108.26.26:7047/DynamicsNAV80/WS/Febi/Codeunit/B2BManagement";
                ws.Credentials = new System.Net.NetworkCredential("navision", "N@vision2014@", "FEBIITALIA");

                decimal price = ws.GetSalesPrice(CustomerNo, PostingDate, ItemNo, Quantity, UoM, CampaignCode);
                MessageBox.Show("Prezzo: " + price.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message + " - Dettagli: " + ex.InnerException);
            }
        }
    }
}
