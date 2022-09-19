using Microsoft.Extensions.Hosting;
using Server.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class TimeredHostedServicecs : IHostedService, IDisposable
    {
        private Timer _timer;


        private readonly IRepository _filmRepository;

        public TimeredHostedServicecs(IRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _filmRepository.WriteToFile();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
