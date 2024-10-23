using System.Collections.Generic;
using Xunit;
using HackathonProblem.Models;
using HackathonProblem.Services;


public class HrDirectorTests
{
    private readonly Config _config;

    public HrDirectorTests()
    {
        this._config = new Config(10, 20, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");
    }

    private List<T> GenerateParticipants<T>(int count, string namePrefix) where T : HackathonParticipant
    {
        List<T> list = new List<T>();
        var constructor = typeof(T).GetConstructor(new[] { typeof(int), typeof(string), typeof(Config) });

        if (constructor == null)
        {
            throw new InvalidOperationException($"Type {typeof(T).Name} does not have a suitable constructor.");
        }

        for (int i = 0; i < count; i++)
        {
            T participant = (T)constructor.Invoke(new object[] { i, $"{namePrefix}{i}", this._config });
            list.Add(participant);
        }

        return list;
    }

    private List<Junior> GenerateJuniors() => GenerateParticipants<Junior>(this._config.teamsCount, "Junior");

    private List<TeamLead> GenerateTeamLeads() => GenerateParticipants<TeamLead>(this._config.teamsCount, "TeamLead");

    [Fact]
    public void CalculateHarmonicity_ShouldReturnCorrectValue_ForValidInput()
    {
        // Arrange.
        List<Junior> juniors = this.GenerateJuniors();
        List<TeamLead> teamLeads = this.GenerateTeamLeads();
        HrDirector hrDirector = new HrDirector();
        ITeamBuildingStrategy teamBuildingStrategy = new DumbBuildingStrategy();
        ParticipantLoader participantLoader = new ParticipantLoader();
        HrManager hrManager = new HrManager(participantLoader, teamBuildingStrategy, this._config);
        Hackathon hackathon = new Hackathon(hrManager, juniors, teamLeads, this._config);

        // Act.
        double harmonicity = hrDirector.CalculateHarmonicity(hackathon.teams);

        // Assert.
        Assert.Equal(5.555, harmonicity, 2);
    }

    [Fact]
    public void CalculateHarmonicity_ShouldHandleEmptyPairsList()
    {
        // Arrange.
        List<Pair> pairs = new List<Pair>();
        HrDirector hrDirector = new HrDirector();

        // Act & Assert.
        Assert.Throws<System.DivideByZeroException>(() =>
            hrDirector.CalculateHarmonicity(pairs));
    }
}

