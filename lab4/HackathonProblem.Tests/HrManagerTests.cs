using Moq;
using HackathonProblem.Models;
using HackathonProblem.Services;

public class HrManagerTests
{
    private readonly Mock<EmployeeLoader> _mockParticipantLoader;
    private readonly Mock<ITeamBuildingStrategy> _mockTeamBuildingStrategy;
    private readonly HackathonOptions _config;
    private readonly HrManager _hrManager;

    public HrManagerTests()
    {
        _mockParticipantLoader = new Mock<EmployeeLoader>();
        _mockTeamBuildingStrategy = new Mock<ITeamBuildingStrategy>();

        _config = new HackathonOptions();
        _config.hackathonCount = 1;
        _config.teamsCount = 40;
        _config.juniorsPath = "../../../../../CSHARP_2024_NSU/Juniors20.csv";
        _config.teamLeadsPath = "../../../../../CSHARP_2024_NSU/TeamLeads20.csv";

        _hrManager = new HrManager(_mockTeamBuildingStrategy.Object, _config);
    }

    [Fact]
    public void BuildTeams_ShouldReturnListOfPairs()
    {
        // Arrange.
        List<Employee> juniors = new List<Employee> { new Employee(0, "Junior0"), new Employee(1, "Junior1") };
        List<Employee> teamLeads = new List<Employee> { new Employee(0, "TeamLead0"), new Employee(1, "TeamLead1") };
        List<Team> expectedTeams = new List<Team> { new Team(teamLeads[0], juniors[0]), new Team(teamLeads[1], juniors[1]) };
        List<Wishlist> teamLeadsWishlists = new List<Wishlist>(
            new Wishlist[]
            {
                new Wishlist(1, new int[] { 1, 2 }),
                new Wishlist(2, new int[] { 1, 2 })
            }
        );
        List<Wishlist> juniorsWishlists = new List<Wishlist>(
            new Wishlist[]
            {
                new Wishlist(1, new int[] { 1, 2 }),
                new Wishlist(2, new int[] { 1, 2 })
            }
        );

        _mockTeamBuildingStrategy.Setup(t => t.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists, _config)).Returns(expectedTeams);

        // Act.
        List<Team> teams = _hrManager.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists, _config);

        // Assert.
        Assert.Equal(expectedTeams, teams);
        _mockTeamBuildingStrategy.Verify(t => t.BuildTeams(teamLeads, juniors, teamLeadsWishlists, juniorsWishlists, _config), Times.Once);
    }
}
