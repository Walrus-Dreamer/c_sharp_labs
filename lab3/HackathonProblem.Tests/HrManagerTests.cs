using System;
using System.Linq;
using HackathonProblem.Models;
using HackathonProblem.Services;
using HackathonProblem.Utils;
using Xunit;

namespace HackathonProblem.Tests
{
    public class HrManagerTests
    {
        Config config = ConfigReader.ReadConfig("../../../../config.json"); // TODO: Задавать конфиг в коде.

        [Fact]
        public void HrManager_ShouldCreateCorrectNumberOfTeams()
        {
            ParticipantLoader participantLoader = new ParticipantLoader();
            var juniors = new List<Junior>
            {
                new Junior(0, "John", this.config),
                new Junior(1, "Jane", this.config)
            };

            var teamLeads = new List<TeamLead>
            {
                new TeamLead(0, "TeamLead1", this.config),
                new TeamLead(1, "TeamLead2", this.config)
            };

            Hackathon hackathon = new Hackathon(juniors, teamLeads, new RandomTeamBuildingStrategy(), this.config);


            Assert.Equal(juniors.Count, hackathon.team.Count);
        }

        [Fact]
        public void HrManager_ShouldReturnPredefinedDistribution()
        {
            var juniors = new List<Junior>
            {
                new Junior(0, "John", this.config),
                new Junior(1, "Jane", this.config)
            };

            var teamLeads = new List<TeamLead>
            {
                new TeamLead(0, "TeamLead1", this.config),
                new TeamLead(1, "TeamLead2", this.config)
            };

            juniors[0].Wishlist = new List<int> { 0, 1, 2 };
            teamLeads[0].Wishlist = new List<int> { 0, 1, 2 };


            Hackathon hackathon = new Hackathon(juniors, teamLeads, new RandomTeamBuildingStrategy(), this.config);


            Assert.Equal(0, hackathon.team[0].junior.id);
            Assert.Equal(0, hackathon.team[0].teamLead.id);
        }
    }
}
