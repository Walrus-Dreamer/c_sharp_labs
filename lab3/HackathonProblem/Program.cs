using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HackathonProblem.Services;
using HackathonProblem.Utils;
using HackathonProblem.Models;

namespace HackathonProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Config config = ConfigReader.ReadConfig("../config.json");
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(config);
                    services.AddHostedService<HackathonWorker>();
                    services.AddTransient<HrManager>();
                    services.AddTransient<HrDirector>();
                    services.AddTransient<ParticipantLoader>();
                    services.AddScoped<ITeamBuildingStrategy, RandomTeamBuildingStrategy>();
                })
                .Build();

            host.Run();
        }
    }
}
