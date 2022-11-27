using GracefullEvictionWorker;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        Banner.Print();
        services.AddHostedService<Worker>();
        
    })
    .Build();

await host.RunAsync();
