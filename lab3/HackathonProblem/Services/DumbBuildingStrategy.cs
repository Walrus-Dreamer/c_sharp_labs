using System;
using System.Collections.Generic;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class DumbBuildingStrategy : ITeamBuildingStrategy
    {
        public List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads, Config config)
        {
            var team = new List<Pair>();

            for (int i = 0; i < config.teamsCount; i++)
            {
                team.Add(new Pair(teamLeads[i], juniors[i], config));
            }

            return team;
        }
    }
}
