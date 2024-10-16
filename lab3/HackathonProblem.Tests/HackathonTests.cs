namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using HackathonProblem.Utils;
using HackathonProblem.Services;
using System.Collections.Generic;
using Xunit;

public class HackathonTests
{
    Config config = ConfigReader.ReadConfig("../../../../config.json"); // TODO: Задавать конфиг в коде.

    [Fact]
    public void Hackathon_ShouldReturnPredefinedHarmonicityLevel()
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

        var hrDirector = new HrDirector();
        // var teamBuildingStrategy = new RandomTeamBuildingStrategy();
        var teamBuildingStrategy = new DumbBuildingStrategy();
        var hackathon = new Hackathon(juniors, teamLeads, teamBuildingStrategy, this.config);


        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.juniors, hackathon.teamLeads, hackathon.team, this.config);


        Assert.Equal(1.33, harmonicity, 2);
    }
}

