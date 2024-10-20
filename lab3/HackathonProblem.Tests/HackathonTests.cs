namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using HackathonProblem.Utils;
using HackathonProblem.Services;
using System.Collections.Generic;
using Xunit;

public class HackathonTests
{
    private Config config = new Config(10, 20, "../../CSHARP_2024_NSU/juniors.txt", "../../CSHARP_2024_NSU/teamLeads.txt");

    private List<T> GenerateParticipants<T>(int count, string namePrefix) where T : HackathonParticipant
    {
        var list = new List<T>();
        var constructor = typeof(T).GetConstructor(new[] { typeof(int), typeof(string), typeof(Config) });

        if (constructor == null)
        {
            throw new InvalidOperationException($"Type {typeof(T).Name} does not have a suitable constructor.");
        }

        for (int i = 0; i < count; i++)
        {
            var participant = (T)constructor.Invoke(new object[] { i, $"{namePrefix}{i}", this.config });
            list.Add(participant);
        }

        return list;
    }

    private List<Junior> GenerateJuniors() => GenerateParticipants<Junior>(this.config.teamsCount, "Junior");

    private List<TeamLead> GenerateTeamLeads() => GenerateParticipants<TeamLead>(this.config.teamsCount, "TeamLead");


    [Fact]
    public void Hackathon_ShouldReturnPredefinedHarmonicityLevel()
    {
        // Arrange.
        var juniors = this.GenerateJuniors();
        var teamLeads = this.GenerateTeamLeads();

        var hrDirector = new HrDirector();
        var teamBuildingStrategy = new DumbBuildingStrategy();
        var hackathon = new Hackathon(juniors, teamLeads, teamBuildingStrategy, this.config);

        // Act.
        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.juniors, hackathon.teamLeads, hackathon.team, this.config);

        // Assert.
        Assert.Equal(5.555, harmonicity, 2);
    }
}

