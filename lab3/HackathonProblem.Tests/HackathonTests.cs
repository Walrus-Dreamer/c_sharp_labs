namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using HackathonProblem.Services;
using System.Collections.Generic;
using Xunit;

public class HackathonTests
{
    private readonly Config _config = new Config(10, 20, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");

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
            var participant = (T)constructor.Invoke(new object[] { i, $"{namePrefix}{i}", this._config });
            list.Add(participant);
        }

        return list;
    }

    private List<Junior> GenerateJuniors() => GenerateParticipants<Junior>(this._config.teamsCount, "Junior");

    private List<TeamLead> GenerateTeamLeads() => GenerateParticipants<TeamLead>(this._config.teamsCount, "TeamLead");

    [Fact]
    public void Hackathon_ShouldReturnPredefinedHarmonicityLevel()
    {
        // Arrange.
        var juniors = this.GenerateJuniors();
        var teamLeads = this.GenerateTeamLeads();
        var hrDirector = new HrDirector();
        var teamBuildingStrategy = new DumbBuildingStrategy();
        var hackathon = new Hackathon(juniors, teamLeads, teamBuildingStrategy, this._config);

        // Act.
        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.juniors, hackathon.teamLeads, hackathon.team, this._config);

        // Assert.
        Assert.Equal(5.555, harmonicity, 2);
    }

    [Fact]
    public void Hackathon_ShouldGenerateCorrectNumberOfJuniors()
    {
        // Arrange & Act.
        var juniors = this.GenerateJuniors();

        // Assert.
        Assert.Equal(this._config.teamsCount, juniors.Count);
        Assert.All(juniors, junior => Assert.IsType<Junior>(junior));
    }

    [Fact]
    public void Hackathon_ShouldGenerateCorrectNumberOfTeamLeads()
    {
        // Arrange & Act.
        var teamLeads = this.GenerateTeamLeads();

        // Assert.
        Assert.Equal(this._config.teamsCount, teamLeads.Count);
        Assert.All(teamLeads, teamLead => Assert.IsType<TeamLead>(teamLead));
    }

    [Fact]
    public void Hackathon_ShouldHandleZeroTeams()
    {
        // Arrange.
        var zeroConfig = new Config(0, 0, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");

        // Act.
        var juniors = GenerateParticipants<Junior>(zeroConfig.teamsCount, "Junior");
        var teamLeads = GenerateParticipants<TeamLead>(zeroConfig.teamsCount, "TeamLead");

        // Assert.
        Assert.Empty(juniors);
        Assert.Empty(teamLeads);
    }
}
