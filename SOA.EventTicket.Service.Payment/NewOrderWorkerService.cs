using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rebus.Activation;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.Payment
{
    public class NewOrderWorkerService : BackgroundService
    {
        //private readonly ILogger<NewOrderWorkerService> _logger;
        private readonly IConfiguration _config;

        public NewOrderWorkerService( IConfiguration config)
        {
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var storageAccount = CloudStorageAccount.Parse(
                _config["AzureQueues:ConnectionString"]);

            using var activator = new BuiltinHandlerActivator();
            activator.Register(() => new NewOrderHandler());
            Configure.With(activator)
                .Transport(t => t.UseAzureStorageQueues(
                    storageAccount, _config["AzureQueues:QueueName"]))
                .Start();

            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
    }
}
