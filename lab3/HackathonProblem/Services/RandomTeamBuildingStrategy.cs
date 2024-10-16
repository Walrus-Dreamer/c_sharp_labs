using System;
using System.Collections.Generic;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class RandomTeamBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads, Config config)
        {
            Random random = new Random();
            var juniorIndices = Enumerable.Range(0, juniors.Count).OrderBy(x => random.Next()).ToList();
            var teamLeadIndices = Enumerable.Range(0, teamLeads.Count).OrderBy(x => random.Next()).ToList();

            var team = new List<Pair>();

            for (int i = 0; i < juniors.Count; i++)
            {
                team.Add(new Pair(teamLeads[teamLeadIndices[i]], juniors[juniorIndices[i]], config));
            }

            return team;
        }
    }
}
