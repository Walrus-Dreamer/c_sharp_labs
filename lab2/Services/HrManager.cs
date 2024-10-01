using HackathonApp.Models;

namespace HackathonApp.Services
{
    public class HrManager
    {
        private readonly ITeamBuildingStrategy _strategy;

        public HrManager(ITeamBuildingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void OrganizeHackathons(int count, HrDirector director)
        {
            double totalHarmonicity = 0;

            for (int i = 0; i < count; i++)
            {
                var hackathon = new Hackathon("../CSHARP_2024_NSU/Juniors20.csv", "../CSHARP_2024_NSU/TeamLeads20.csv");
                double harmonicity = hackathon.CalculateHarmonicity();
                totalHarmonicity += harmonicity;
                director.ReceiveHackathonResults(harmonicity);
            }

            Console.WriteLine($"Average Harmonicity: {totalHarmonicity / count:F2}");
        }
    }
}
