using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InciCafeUpdateStatusWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private HttpClient client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var response = await client.GetAsync("http://localhost:5002/api/orders/Update");
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Website working at : {time}", DateTimeOffset.Now);
                }


                await Task.Delay(10000, stoppingToken);


            }
        }
    }
}
