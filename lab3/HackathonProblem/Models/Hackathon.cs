using HackathonProblem.Services;
using System;
using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public class Hackathon
    {
        public HrManager hrManager { get; set; }
        public List<Junior> juniors { get; set; }
        public List<TeamLead> teamLeads { get; set; }
        public List<Pair> team { get; set; }

        public Hackathon(HrManager hrManager, List<Junior> juniors, List<TeamLead> teamLeads, Config config)
        {
            this.hrManager = hrManager;
            this.juniors = juniors;
            this.teamLeads = teamLeads;
            this.team = this.hrManager.BuildTeams(juniors, teamLeads);
        }
    }
}
