﻿using Azure.Storage.Queues;
using System.Threading.Tasks;

namespace ST10251759_CLDV6212_POE_Par1.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;


        public QueueService(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);
        }

        public async Task SendMessageAsync(string message)
        {
            await _queueClient.SendMessageAsync(message);
        }
    }
}
