namespace HackathonProblem.Tests;

using HackathonProblem.Models;
using Xunit;

public class ConfigTests
{
    [Fact]
    public void Config_ShouldThrowExceptionForNegativeHackathonsCount()
    {
        // Arrange & Act & Assert.
        Assert.Throws<ArgumentOutOfRangeException>(() => new HackathonOptions(-1, 10, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv"));
    }

    [Fact]
    public void Config_ShouldThrowExceptionForNegativeTeamsCount()
    {
        // Arrange & Act & Assert.
        Assert.Throws<ArgumentOutOfRangeException>(() => new HackathonOptions(10, -1, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv"));
    }

    [Fact]
    public void Config_ShouldThrowExceptionForIncorrectJuniorsPath()
    {
        // Arrange & Act & Assert.
        Assert.Throws<ArgumentException>(() => new HackathonOptions(10, 10, "beer", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv"));
    }

    [Fact]
    public void Config_ShouldThrowExceptionForIncorrectTeamLeadsPath()
    {
        // Arrange & Act & Assert.
        Assert.Throws<ArgumentException>(() => new HackathonOptions(10, 10, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "beer"));
    }
}
