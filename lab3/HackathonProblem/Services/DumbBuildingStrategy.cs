using System;
using System.Collections.Generic;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class DumbBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            var juniorIndices = Enumerable.Range(0, juniors.Count).ToList();
            var teamLeadIndices = Enumerable.Range(0, teamLeads.Count).ToList();

            var Team = new List<Pair>();

            for (int i = 0; i < juniors.Count; i++)
            {
                Team.Add(new Pair(teamLeadIndices[i], juniorIndices[i]));
            }

            return Team;
        }
    }
}
