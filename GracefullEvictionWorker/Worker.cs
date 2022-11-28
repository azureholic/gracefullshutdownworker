using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace GracefullEvictionWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration _config;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private bool _stopExecuting = false;
        private QueueClient _queueClient;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, IConfiguration config)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _config = config;
            _logger = logger;
            _logger.LogInformation("Starting Worker");
            string connection = _config["StorageSettings:StorageConnectionString"];
            string queue = _config["StorageSettings:StorageQueueName"];
            _queueClient = new QueueClient(connection, queue);
            _hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var handler = new Handler();
            _logger.LogInformation("Execute has been called)");
            while (!stoppingToken.IsCancellationRequested && !_stopExecuting)
            {
                if (_queueClient.Exists())
                {
                    // Get the next message
                    QueueMessage[] retrievedMessage = await _queueClient.ReceiveMessagesAsync(1);

                    if (retrievedMessage.Length != 0)
                    {
                        Console.WriteLine($"Dequeued message: '{retrievedMessage[0].Body}'");
                        await handler.DoWork(retrievedMessage[0].Body.ToString());
                        _queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
                    }
                }
                
                //call next handler in 1 second to prevent to much presure on the queue
                await Task.Delay(1000, stoppingToken);
            }

        }

        override public Task StopAsync(CancellationToken cancellationToken)
        {   
            _logger.LogInformation("StopAsync has been called.");
            return Task.CompletedTask;
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
            _logger.LogInformation("SIGTERM received, waiting for 10 seconds");
            _stopExecuting = true;
            
            //this will delay the shutdown for 10 seconds
            Thread.Sleep(10000);

            _logger.LogInformation("Termination delay complete, continuing stopping process");
            
        }

       
    }
}
