using Microsoft.ServiceBus.Messaging;
using System;
//using Microsoft.Azure.ServiceBus;


namespace Triangle.MessageHandler.WS
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://<your namespace>.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=<your key>"; ;
            var topicName = "<your topic name>";

            var client = SubscriptionClient.CreateFromConnectionString(connectionString, topicName, "<your subscription name>");

            Console.WriteLine("Hello World!");

            //var friend = Acto
        }
    }
}
