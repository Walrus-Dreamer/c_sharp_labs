using HackathonApp.Services;
using HackathonApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HackathonApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<HackathonWorker>();
                    services.AddTransient<Hackathon>();
                    services.AddTransient<ITeamBuildingStrategy, RandomTeamBuildingStrategy>();
                    services.AddTransient<HrManager>();
                    services.AddTransient<HrDirector>();
                })
                .Build();

            host.Run();
        }
    }
}
