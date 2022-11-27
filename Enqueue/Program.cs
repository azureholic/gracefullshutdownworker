using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connection = config["StorageSettings:StorageConnectionString"];
string queue = config["StorageSettings:StorageQueueName"];
QueueClient queueClient = new QueueClient(connection, queue);
if (queueClient.Exists())
{

    for (int i = 1; i <= 500; i++)
    {
        string message = $"Hello Worker {i}";
        queueClient.SendMessage(message);
        Console.WriteLine($"Inserted: {message}");
    }
}