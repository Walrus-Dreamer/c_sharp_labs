namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using HackathonProblem.Services;
using System.Collections.Generic;
using Xunit;

public class HackathonTests
{
    [Fact]
    public void Hackathon_ShouldReturnPredefinedHarmonicityLevel()
    {
        var juniors = new List<Junior>
            {
                new Junior("John") { Wishlist = new List<int> { 0, 1, 2 } },
                new Junior("Jane") { Wishlist = new List<int> { 1, 0, 2 } }
            };

        var teamLeads = new List<TeamLead>
            {
                new TeamLead("TeamLead1") { Wishlist = new List<int> { 0, 1 } },
                new TeamLead("TeamLead2") { Wishlist = new List<int> { 1, 0 } }
            };

        var hrDirector = new HrDirector();
        // var teamBuildingStrategy = new RandomTeamBuildingStrategy();
        var teamBuildingStrategy = new DumbBuildingStrategy();
        var hackathon = new Hackathon(juniors, teamLeads, teamBuildingStrategy);


        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.Juniors, hackathon.TeamLeads, hackathon.Team);


        Assert.NotEqual(10.0, harmonicity, 1); // Ожидаемое значение гармоничности
    }
}

