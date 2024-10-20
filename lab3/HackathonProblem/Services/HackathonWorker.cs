using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using HackathonProblem.Models;
using HackathonProblem.Services;
using System.Collections.Generic;

namespace HackathonProblem.Services
{
    public class HackathonWorker : IHostedService
    {
        private readonly HrManager _hrManager;
        private readonly HrDirector _hrDirector;
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;
        private readonly Config _config;

        public HackathonWorker(HrManager hrManager, HrDirector hrDirector, ITeamBuildingStrategy teamBuildingStrategy, Config config)
        {
            this._hrManager = hrManager;
            this._hrDirector = hrDirector;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this._config = config;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            List<Junior> juniors = _hrManager.LoadJuniors();
            List<TeamLead> teamLeads = _hrManager.LoadTeamLeads();

            double totalHarmonicity = 0;
            int hackathonCount = this._config.hackathonCount;

            for (int i = 0; i < hackathonCount; i++)
            {
                var hackathon = new Hackathon(this._hrManager, juniors, teamLeads, this._config);

                double harmonicity = _hrDirector.CalculateHarmonicity(hackathon.juniors, hackathon.teamLeads, hackathon.team, this._config);
                totalHarmonicity += harmonicity;
                Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");
            }

            Console.WriteLine($"Average Harmonicity: {totalHarmonicity / hackathonCount:F2}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
