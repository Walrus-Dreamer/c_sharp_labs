using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HackathonProblem.Services;
using HackathonProblem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace HackathonProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("config.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<HackathonOptions>(hostContext.Configuration.GetSection("HackathonOptions"));
                    services.AddSingleton<IValidateOptions<HackathonOptions>, HackathonOptionsValidation>();

                    services.AddDbContext<HackathonDbContext>(options =>
                        options.UseSqlite("Data Source=hackathon.db"));

                    services.AddHostedService<HackathonWorker>();
                    services.AddTransient<HrManager>();
                    services.AddTransient<HrDirector>();
                    services.AddTransient<EmployeeLoader>();
                    services.AddScoped<ITeamBuildingStrategy, DumbBuildingStrategy>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HackathonDbContext>();
                dbContext.Database.EnsureCreated();
            }

            host.Run();
        }
    }
}