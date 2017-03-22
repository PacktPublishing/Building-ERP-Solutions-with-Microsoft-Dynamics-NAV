using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ServiceBus.Messaging;
using System.Threading;
using System.Runtime.Serialization;
using NAVAzureServiceBus.NAVSalesOrderWS;
using NAVAzureServiceBus.Classes;

namespace NAVAzureServiceBus
{
    class Program
    {
        static string ServiceBusConnectionString = "Endpoint=sb://navsbqueue-ns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=GD2cxyENOHyATwzFVAK0bF9AVJjDB+n42i6wZFkVhXI=";

        static string QueueName = "NAVSBQueue";
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(" Parameters:");
                Console.WriteLine("   S: send orders to Azure Service Bus");
                Console.WriteLine("   R: receive orders from Azure Service Bus");
                Console.WriteLine("----------------------------------------------------------");
                return;
            }                      

            string OperationType = args[0].ToUpper();

            switch(OperationType)
            {
                case "S":
                    SendOrders();
                    break;
                case "R":
                    ReceiveOrders();
                    break;
            }

            Console.ReadLine();
        }

        private static void HandleTransientErrors(MessagingException e)
        {
            //If transient error/exception, let’s back-off for 2 seconds and retry 
            Console.WriteLine(e.Message);
            Console.WriteLine("Will retry sending the message in 2 seconds");
            Thread.Sleep(2000);
        }

        //Send Orders to Azure Service Bus
        private static void SendOrders()
        {
            Console.WriteLine("\nSending message to Azure Service Bus Queue…");
            try
            {
                ShopAppInterface SI = new ShopAppInterface();

                ShopSalesOrder order = SI.GetNAVOrder();

                var client = QueueClient.CreateFromConnectionString(ServiceBusConnectionString, QueueName);

                BrokeredMessage message = new BrokeredMessage(order, new DataContractSerializer(typeof(ShopSalesOrder)));

                client.Send(message);
            }
            catch(Exception ex)
            {
                //Handle exception here...
            }
        }

        //Receives Orders from Azure Service Bus 
        private static void ReceiveOrders()
        {
            Console.WriteLine("\nReceiving message from Azure Service Bus Queue…");
            try
            {
                var client = QueueClient.CreateFromConnectionString(ServiceBusConnectionString, QueueName);

                while (true)
                {
                    try
                    {
                        //receive messages from Queue 
                        BrokeredMessage message = client.Receive(TimeSpan.FromSeconds(5));

                        if (message != null)
                        {
                            //Ricezione messaggio di testo
                            //Console.WriteLine(string.Format("Message received: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>()));

                            //Retrieves the order object
                            Console.WriteLine(string.Format("Message received: Id = {0} ", message.MessageId));
                            ShopSalesOrder orderReceived = message.GetBody<ShopSalesOrder>(new DataContractSerializer(typeof(ShopSalesOrder)));

                            //Send the order to NAV
                            NAVInterface NAV = new NAVInterface();
                            NAV.CreateNAVSalesOrder(orderReceived);

                            // Further custom message processing could go here… 
                            message.Complete();
                        }
                        else
                        {
                            //no more messages in the queue 
                            break;
                        }
                    }
                    catch (MessagingException e)
                    {
                        if (!e.IsTransient)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        else
                        {
                            HandleTransientErrors(e);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //Handle exception here...
            }
        }

        

    }
}
