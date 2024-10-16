using HackathonProblem.Services;
using System;
using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public class Hackathon
    {
        public List<Junior> juniors { get; set; }
        public List<TeamLead> teamLeads { get; set; }
        public List<Pair> team { get; set; }
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public Hackathon(List<Junior> juniors, List<TeamLead> teamLeads, ITeamBuildingStrategy teamBuildingStrategy, Config config)
        {
            this.juniors = juniors;
            this.teamLeads = teamLeads;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this.team = _teamBuildingStrategy.BuildTeams(juniors, teamLeads, config);
        }
    }
}
