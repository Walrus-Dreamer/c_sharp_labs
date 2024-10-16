namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using HackathonProblem.Utils;
using HackathonProblem.Services;
using System.Collections.Generic;
using Xunit;

public class HackathonTests
{
    [Fact]
    public void Hackathon_ShouldReturnPredefinedHarmonicityLevel()
    {
        Config config = ConfigReader.ReadConfig("../../../../config.json");
        var juniors = new List<Junior>
            {
                new Junior(0, "John", config),
                new Junior(1, "Jane", config)
            };

        var teamLeads = new List<TeamLead>
            {
                new TeamLead(0, "TeamLead1", config),
                new TeamLead(1, "TeamLead2", config)
            };

        var hrDirector = new HrDirector();
        // var teamBuildingStrategy = new RandomTeamBuildingStrategy();
        var teamBuildingStrategy = new DumbBuildingStrategy();
        var hackathon = new Hackathon(juniors, teamLeads, teamBuildingStrategy, config);


        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.juniors, hackathon.teamLeads, hackathon.team, config);


        Assert.Equal(1.33, harmonicity, 2);
    }
}

