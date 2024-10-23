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
            List<int> juniorIndexes = Enumerable.Range(0, config.teamsCount).OrderBy(x => random.Next()).ToList();
            List<int> teamLeadIndexes = Enumerable.Range(0, config.teamsCount).OrderBy(x => random.Next()).ToList();

            List<Pair> team = new List<Pair>();
            for (int i = 0; i < config.teamsCount; i++)
            {
                TeamLead pickedTeamLead = teamLeads[teamLeadIndexes[i]];
                Junior pickedJunior = juniors[juniorIndexes[i]];
                team.Add(new Pair(pickedTeamLead, pickedJunior, config));
            }

            return team;
        }
    }
}
