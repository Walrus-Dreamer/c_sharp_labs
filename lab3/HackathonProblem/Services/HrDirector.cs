using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrDirector
    {
        private int GetSatisfactionIndex(int[] wishlist, int pickedTeammateId)
        {
            for (int teammateIndex = 0; teammateIndex < wishlist.Length; teammateIndex++)
            {
                if (wishlist[teammateIndex] == pickedTeammateId)
                {
                    return wishlist.Length - teammateIndex;
                }
            }
            return 0;
        }

        public double CalculateHarmonicity(Hackathon hackathon)
        {
            double harmonicityDivisor = 0;
            int teamsCount = hackathon.teams.Count;

            if (teamsCount == 0)
            {
                throw new System.DivideByZeroException("No teams found.");
            }

            foreach (Team team in hackathon.teams)
            {
                int teamLeadId = team.TeamLead.id;
                Wishlist teamLeadWishlist = hackathon.teamLeadsWishlists.First(w => w.EmployeeId == teamLeadId);

                int juniorId = team.Junior.id;
                Wishlist juniorWishlist = hackathon.juniorsWishlists.First(w => w.EmployeeId == juniorId);

                int teamLeadSatisfaction = GetSatisfactionIndex(teamLeadWishlist.DesiredEmployees, juniorId);
                int juniorSatisfaction = GetSatisfactionIndex(juniorWishlist.DesiredEmployees, teamLeadId);

                harmonicityDivisor += 1.0 / juniorSatisfaction + 1.0 / teamLeadSatisfaction;
            }

            return 2 * teamsCount / harmonicityDivisor;
        }
    }
}
