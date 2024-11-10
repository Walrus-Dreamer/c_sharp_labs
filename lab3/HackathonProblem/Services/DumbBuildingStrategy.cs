using System;
using System.Collections.Generic;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class DumbBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Team> BuildTeams(List<Employee> teamLeads, List<Employee> juniors,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists, Config config)
        {
            List<Team> team = new List<Team>();

            for (int i = 0; i < config.teamsCount; i++)
            {
                team.Add(new Team(teamLeads[i], juniors[i]));
            }
            return team;
        }
    }
}
