using Microsoft.Extensions.Hosting;
using HackathonProblem.Models;
using Microsoft.Extensions.Options;

namespace HackathonProblem.Services
{
    public class HackathonWorker : IHostedService
    {
        private readonly EmployeeLoader _employeeLoader;
        private readonly HrDirector _hrDirector;
        private readonly IServiceProvider _serviceProvider;  // Service provider to create scoped services

        private readonly HackathonOptions _config;

        public HackathonWorker(
            EmployeeLoader employeeLoader,
            HrDirector hrDirector,
            IServiceProvider serviceProvider,  // Inject the service provider to resolve scoped services
            IOptions<HackathonOptions> config)
        {
            _employeeLoader = employeeLoader;
            _hrDirector = hrDirector;
            _serviceProvider = serviceProvider;
            _config = config.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            LoadedEmployees loadedEmployees = _employeeLoader.LoadEmployees(_config);
            List<Employee> juniors = loadedEmployees.juniors;
            List<Employee> teamLeads = loadedEmployees.teamLeads;

            double totalHarmonicity = 0;
            int hackathonCount = _config.hackathonCount;

            for (int i = 0; i < hackathonCount; i++)
            {
                // Use a scope to resolve scoped services like ITeamBuildingStrategy
                using (var scope = _serviceProvider.CreateScope())
                {
                    var teamBuildingStrategy = scope.ServiceProvider.GetRequiredService<ITeamBuildingStrategy>();
                    var hrManager = new HrManager(teamBuildingStrategy, _config);  // Pass the scoped teamBuildingStrategy

                    List<Wishlist> teamLeadsWishlists = hrManager.GetWishlists(teamLeads);
                    List<Wishlist> juniorsWishlists = hrManager.GetWishlists(juniors);
                    List<Team> teams = hrManager.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists, _config);

                    Hackathon hackathon = new Hackathon(teams, teamLeadsWishlists, juniorsWishlists);
                    double harmonicity = _hrDirector.CalculateHarmonicity(hackathon);

                    totalHarmonicity += harmonicity;

                    Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");

                    // Save the hackathon to the database
                    var hackathonEntity = new HackathonEntity
                    {
                        Name = $"Hackathon {i + 1}",
                        HarmonyScore = harmonicity,
                        Teams = teams.Select(team => new TeamEntity
                        {
                            TeamLead = new ParticipantEntity { Name = team.TeamLead.name, Role = "TeamLead" },
                            Junior = new ParticipantEntity { Name = team.Junior.name, Role = "Junior" }
                        }).ToList()
                    };

                    var dbContext = scope.ServiceProvider.GetRequiredService<HackathonDbContext>(); // Resolve DbContext in scope
                    dbContext.Hackathons.Add(hackathonEntity);
                    await dbContext.SaveChangesAsync(cancellationToken);  // Save inside scope
                }
            }

            Console.WriteLine($"Average Harmonicity: {totalHarmonicity / hackathonCount:F2}");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
