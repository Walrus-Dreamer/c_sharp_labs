using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using HackathonApp.Models;
using HackathonApp.Services;
using System.Collections.Generic;

namespace HackathonApp.Services
{
    public class HackathonWorker : IHostedService
    {
        private readonly HrManager _hrManager;
        private readonly HrDirector _hrDirector;
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public HackathonWorker(HrManager hrManager, HrDirector hrDirector, ITeamBuildingStrategy teamBuildingStrategy)
        {
            _hrManager = hrManager;
            _hrDirector = hrDirector;
            _teamBuildingStrategy = teamBuildingStrategy;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            List<Junior> juniors = _hrManager.LoadJuniors();
            List<TeamLead> teamLeads = _hrManager.LoadTeamLeads();

            for (int i = 0; i < 1000; i++)
            {
                var hackathon = new Hackathon(juniors, teamLeads, _teamBuildingStrategy);
                double harmonicity = hackathon.CalculateHarmonicity();
                Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
