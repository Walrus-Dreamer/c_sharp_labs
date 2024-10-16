using System.Collections.Generic;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrDirector
    {
        public double CalculateHarmonicity(List<Junior> juniors, List<TeamLead> teamLeads, List<Pair> pairs)
        {
            double harmonicityDivisor = 0;
            int maxSatisfaction = juniors.Count;

            foreach (var pair in pairs)
            {
                int juniorSatisfaction = pair.JuniorSatisfaction;
                // int teamLeadSatisfaction = maxSatisfaction - teamLeads[pair.TeamLeadId].Wishlist[pair.JuniorId] + 1; // If Junior is top 1 for TeamLead, than TeamLead will be satisfied by maxSatisfaction points.
                int teamLeadSatisfaction = pair.TeamLeadSatisfaction;

                harmonicityDivisor += 1.0 / juniorSatisfaction + 1.0 / teamLeadSatisfaction;
            }

            return juniors.Count / harmonicityDivisor;
        }
    }
}
