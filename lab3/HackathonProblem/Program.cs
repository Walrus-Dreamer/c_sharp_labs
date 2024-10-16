﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HackathonProblem.Services;

namespace HackathonProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
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
