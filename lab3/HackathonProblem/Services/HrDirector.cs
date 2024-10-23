using System.Collections.Generic;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrDirector
    {
        public double CalculateHarmonicity(List<Pair> pairs)
        {
            double harmonicityDivisor = 0;
            int teamsCount = pairs.Count;
            if (teamsCount == 0)
            {
                throw new System.DivideByZeroException("No pairs found.");
            }

            foreach (Pair pair in pairs)
            {
                int juniorSatisfaction = pair.JuniorSatisfaction;
                int teamLeadSatisfaction = pair.TeamLeadSatisfaction;

                harmonicityDivisor += 1.0 / juniorSatisfaction + 1.0 / teamLeadSatisfaction;
            }

            return 2 * teamsCount / harmonicityDivisor;
        }
    }
}
