using Moq;
using HackathonProblem.Models;
using HackathonProblem.Services;

public class HrManagerTests
{
    private readonly Mock<ParticipantLoader> _mockParticipantLoader;
    private readonly Mock<ITeamBuildingStrategy> _mockTeamBuildingStrategy;
    private readonly Config _config;
    private readonly HrManager _hrManager;

    public HrManagerTests()
    {
        _mockParticipantLoader = new Mock<ParticipantLoader>();
        _mockTeamBuildingStrategy = new Mock<ITeamBuildingStrategy>();

        _config = new Config(10, 20, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");

        _hrManager = new HrManager(_mockParticipantLoader.Object, _mockTeamBuildingStrategy.Object, _config);
    }

    [Fact]
    public void LoadJuniors_ShouldReturnJuniorsList()
    {
        // Arrange.
        List<Junior> expectedJuniors = new List<Junior> { new Junior(0, "Junior0", this._config), new Junior(1, "Junior1", this._config) };
        _mockParticipantLoader.Setup(p => p.LoadJuniors(_config.juniorsPath, _config)).Returns(expectedJuniors);

        // Act.
        List<Junior> juniors = _hrManager.LoadJuniors();

        // Assert.
        Assert.Equal(expectedJuniors, juniors);
        _mockParticipantLoader.Verify(p => p.LoadJuniors(_config.juniorsPath, _config), Times.Once);
    }

    [Fact]
    public void LoadTeamLeads_ShouldReturnTeamLeadsList()
    {
        // Arrange.
        List<TeamLead> expectedTeamLeads = new List<TeamLead> { new TeamLead(0, "TeamLead0", this._config), new TeamLead(1, "TeamLead1", this._config) };
        _mockParticipantLoader.Setup(p => p.LoadTeamLeads(_config.teamLeadsPath, _config)).Returns(expectedTeamLeads);

        // Act.
        List<TeamLead> teamLeads = _hrManager.LoadTeamLeads();

        // Assert.
        Assert.Equal(expectedTeamLeads, teamLeads);
        _mockParticipantLoader.Verify(p => p.LoadTeamLeads(_config.teamLeadsPath, _config), Times.Once);
    }

    [Fact]
    public void BuildTeams_ShouldReturnListOfPairs()
    {
        // Arrange.
        List<Junior> juniors = new List<Junior> { new Junior(0, "Junior0", this._config), new Junior(1, "Junior1", this._config) };
        List<TeamLead> teamLeads = new List<TeamLead> { new TeamLead(0, "TeamLead0", this._config), new TeamLead(1, "TeamLead1", this._config) };
        List<Pair> expectedPairs = new List<Pair> { new Pair(teamLeads[0], juniors[0], _config), new Pair(teamLeads[1], juniors[1], _config) };

        _mockTeamBuildingStrategy.Setup(t => t.BuildTeams(juniors, teamLeads, _config)).Returns(expectedPairs);

        // Act.
        List<Pair> pairs = _hrManager.BuildTeams(juniors, teamLeads);

        // Assert.
        Assert.Equal(expectedPairs, pairs);
        _mockTeamBuildingStrategy.Verify(t => t.BuildTeams(juniors, teamLeads, _config), Times.Once);
    }
}
