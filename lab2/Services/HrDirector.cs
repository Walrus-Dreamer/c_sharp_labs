using System.Collections.Generic;
using HackathonApp.Models;

namespace HackathonApp.Services
{
    public class HrDirector
    {
        public double CalculateHarmonicity(List<Junior> juniors, List<TeamLead> teamLeads, List<Pair> pairs)
        {
            double harmonicityDivisor = 0;
            int maxSatisfaction = juniors.Count;

            foreach (var pair in pairs)
            {
                int juniorSatisfaction = maxSatisfaction - juniors[pair.JuniorId].Wishlist[pair.TeamLeadId] + 1; // If TeamLead is top 1 for Junior, than Junior will be satisfied by maxSatisfaction points.
                int teamLeadSatisfaction = maxSatisfaction - teamLeads[pair.TeamLeadId].Wishlist[pair.JuniorId] + 1; // If Junior is top 1 for TeamLead, than TeamLead will be satisfied by maxSatisfaction points.

                harmonicityDivisor += 1.0 / juniorSatisfaction + 1.0 / teamLeadSatisfaction;
            }

            return juniors.Count / harmonicityDivisor;
        }
    }
}
