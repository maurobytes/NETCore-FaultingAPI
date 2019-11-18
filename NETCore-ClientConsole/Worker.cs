using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NETCore_ClientConsole
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient client;

        public Worker(ILogger<Worker> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = _clientFactory.CreateClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await client.GetAsync("http://localhost:59316/weatherforecast");
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Request Succeed with code status: {result.StatusCode}");
                }
                else
                {
                    _logger.LogInformation($"Request Failed with code status: {result.StatusCode}");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
