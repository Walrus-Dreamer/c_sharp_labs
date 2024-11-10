using System;
using System.Collections.Generic;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class RandomTeamBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Team> BuildTeams(List<Employee> teamLeads, List<Employee> juniors,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists, Config config)
        {
            Random random = new Random();
            List<int> juniorIndexes = Enumerable.Range(0, config.teamsCount).OrderBy(x => random.Next()).ToList();
            List<int> teamLeadIndexes = Enumerable.Range(0, config.teamsCount).OrderBy(x => random.Next()).ToList();

            List<Team> team = new List<Team>();
            for (int i = 0; i < config.teamsCount; i++)
            {
                Employee pickedTeamLead = teamLeads[teamLeadIndexes[i]];
                Employee pickedJunior = juniors[juniorIndexes[i]];
                team.Add(new Team(pickedTeamLead, pickedJunior));
            }

            return team;
        }
    }
}
