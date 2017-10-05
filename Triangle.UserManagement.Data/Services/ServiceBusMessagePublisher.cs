using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Triangle.SharedKernel.Interfaces;
using Triangle.UserManagement.Core.Interfaces;
using Newtonsoft.Json;

namespace Triangle.UserManagement.Data.Services
{
    public class ServiceBusMessagePublisher : IMessagePublisher
    {
        const string ServiceBusConnectionString = "{ServiceBus connection string}";
        const string TopicName = "{Topic Name}";


        //const string QueueName = "{Queue Name}";
        //static IMessageSender messageSender;
        //static IMessageReceiver messageReceiver;
        private static ITopicClient _topicClient;
        private static ISubscriptionClient registrationSubscriptionClient;
           

        public async Task Publish(IApplicationEvent applicationEvent, string label = null, string correlationId = null)
        {
            _topicClient = new TopicClient(ServiceBusConnectionString, TopicName);
            await SendMessageAsync(applicationEvent, label, correlationId);
        }

        static async Task SendMessageAsync(IApplicationEvent applicationEvent, string label = null, string correlationId = null)
        {
            string json = JsonConvert.SerializeObject(applicationEvent, Formatting.None);
            Message message = new Message{Body = Encoding.UTF8.GetBytes(json), Label =  label, CorrelationId = correlationId};

            await _topicClient.SendAsync(message);
        }
    }
}