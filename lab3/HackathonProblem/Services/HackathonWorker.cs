using Microsoft.Extensions.Hosting;
using HackathonProblem.Models;
using Microsoft.Extensions.Options;


namespace HackathonProblem.Services
{
    public class HackathonWorker : IHostedService
    {
        private readonly EmployeeLoader _employeeLoader;
        private readonly HrDirector _hrDirector;
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;
        private readonly HackathonOptions _config;

        public HackathonWorker(EmployeeLoader _employeeLoader, HrDirector hrDirector, ITeamBuildingStrategy teamBuildingStrategy, IOptions<HackathonOptions> config)
        {
            this._employeeLoader = _employeeLoader;
            this._hrDirector = hrDirector;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this._config = config.Value;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            LoadedEmployees loadedEmployees = _employeeLoader.LoadEmployees(this._config);
            List<Employee> juniors = loadedEmployees.juniors;
            List<Employee> teamLeads = loadedEmployees.teamLeads;

            double totalHarmonicity = 0;
            int hackathonCount = this._config.hackathonCount;

            for (int i = 0; i < hackathonCount; i++)
            {
                HrManager hrManager = new HrManager(_teamBuildingStrategy, this._config);
                List<Wishlist> teamLeadsWishlists = hrManager.GetWishlists(teamLeads);
                List<Wishlist> juniorsWishlists = hrManager.GetWishlists(juniors);
                List<Team> teams = hrManager.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists, this._config);

                Hackathon hackathon = new Hackathon(teams, teamLeadsWishlists, juniorsWishlists);

                double harmonicity = _hrDirector.CalculateHarmonicity(hackathon);

                totalHarmonicity += harmonicity;
                Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");
            }

            Console.WriteLine($"Average Harmonicity: {totalHarmonicity / hackathonCount:F2}");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
