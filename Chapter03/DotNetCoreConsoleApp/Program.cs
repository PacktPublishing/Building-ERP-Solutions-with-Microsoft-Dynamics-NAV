using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Connecting to NAV services...");

            Task T = new Task(CallNAVWebService);  
            T.Start();   
            Console.ReadLine();  

            HttpClient client = new HttpClient();
          
        }

       static async void CallNAVWebService()  
       {  
           string NAVWSUrl = "....";
           using (var client = new HttpClient())  
           {  
  
               HttpResponseMessage response = await client.GetAsync("NAVWSUrl");  
  
               response.EnsureSuccessStatusCode();  
  
               using (HttpContent content = response.Content)  
               {  
                   string responseBody = await response.Content.ReadAsStringAsync();  
  
                   Console.WriteLine("Reading the NAV response");  

                   //Here you can parse the NAV WS response

                   
  
                   //var orders = JsonConvert.DeserializeObject<List<Order>>(responseBody);  
  
  
  
                   //foreach (var Ord in orders)  
                   //{   
                   //}  
  
               }  
  
           }    
       }  

    }
}
