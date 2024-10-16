using System.Collections.Generic;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrDirector
    {
        public double CalculateHarmonicity(List<Junior> juniors, List<TeamLead> teamLeads, List<Pair> pairs, Config config)
        {
            double harmonicityDivisor = 0;
            int maxSatisfaction = juniors.Count;

            foreach (var pair in pairs)
            {
                int juniorSatisfaction = pair.JuniorSatisfaction;
                int teamLeadSatisfaction = pair.TeamLeadSatisfaction;

                harmonicityDivisor += 1.0 / juniorSatisfaction + 1.0 / teamLeadSatisfaction;
            }

            return 2 * config.teamsCount / harmonicityDivisor;
        }
    }
}
