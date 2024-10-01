using System;
using System.Collections.Generic;
using System.Linq;
using HackathonApp.Models;

namespace HackathonApp.Services
{
    public class RandomTeamBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            Random random = new Random();
            var juniorIndices = Enumerable.Range(0, juniors.Count).OrderBy(x => random.Next()).ToList();
            var teamLeadIndices = Enumerable.Range(0, teamLeads.Count).OrderBy(x => random.Next()).ToList();

            var pairs = new List<Pair>();

            for (int i = 0; i < juniors.Count; i++)
            {
                pairs.Add(new Pair(teamLeadIndices[i], juniorIndices[i]));
            }

            return pairs;
        }
    }
}
