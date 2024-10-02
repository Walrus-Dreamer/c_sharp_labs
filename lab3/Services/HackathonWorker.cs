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

            double totalHarmonicity = 0;
            int hackathonCount = 1000;

            for (int i = 0; i < hackathonCount; i++)
            {
                var hackathon = new Hackathon(juniors, teamLeads, _teamBuildingStrategy);

                double harmonicity = _hrDirector.CalculateHarmonicity(hackathon.Juniors, hackathon.TeamLeads, hackathon.Team);
                totalHarmonicity += harmonicity;
                Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");
            }

            Console.WriteLine($"Average Harmonicity: {totalHarmonicity / hackathonCount:F2}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
