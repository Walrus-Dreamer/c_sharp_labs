using HackathonApp.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HackathonApp.Services
{
    public class HackathonWorker : IHostedService
    {
        private readonly HrManager _hrManager;
        private readonly HrDirector _hrDirector;

        public HackathonWorker(HrManager hrManager, HrDirector hrDirector)
        {
            _hrManager = hrManager;
            _hrDirector = hrDirector;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _hrManager.OrganizeHackathons(1000, _hrDirector);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
