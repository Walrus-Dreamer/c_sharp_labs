// using System.Collections.Generic;
// using Moq;
// using Xunit;
// using HackathonProblem.Models;
// using HackathonProblem.Services;

// namespace HackathonProblem.Tests.Services
// {
//     public class HrManagerTests
//     {
//         private readonly Mock<ParticipantLoader> _mockParticipantLoader;
//         private readonly Config _config;
//         private readonly HrManager _hrManager;

//         public HrManagerTests()
//         {
//             _mockParticipantLoader = new Mock<ParticipantLoader>();
//             _config = new Config(10, 2, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");
//             _hrManager = new HrManager(_mockParticipantLoader.Object, _config);
//         }

//         [Fact]
//         public void LoadJuniors_ShouldCallLoadJuniorsMethodWithCorrectParameters()
//         {
//             // Arrange.
//             var expectedJuniors = new List<Junior>
//             {
//                 new Junior { Name = "Junior 1" },
//                 new Junior { Name = "Junior 2" }
//             };

//             _mockParticipantLoader
//                 .Setup(pl => pl.LoadJuniors(_config.juniorsPath, _config))
//                 .Returns(expectedJuniors);

//             // Act.
//             var juniors = _hrManager.LoadJuniors();

//             // Assert.
//             Assert.Equal(expectedJuniors, juniors);
//             _mockParticipantLoader.Verify(pl => pl.LoadJuniors(_config.juniorsPath, _config), Times.Once);
//         }

//         [Fact]
//         public void LoadTeamLeads_ShouldCallLoadTeamLeadsMethodWithCorrectParameters()
//         {
//             // Arrange.
//             var expectedTeamLeads = new List<TeamLead>
//             {
//                 new TeamLead { Name = "TeamLead 1" },
//                 new TeamLead { Name = "TeamLead 2" }
//             };

//             _mockParticipantLoader
//                 .Setup(pl => pl.LoadTeamLeads(_config.teamLeadsPath, _config))
//                 .Returns(expectedTeamLeads);

//             // Act.
//             var teamLeads = _hrManager.LoadTeamLeads();

//             // Assert.
//             Assert.Equal(expectedTeamLeads, teamLeads);
//             _mockParticipantLoader.Verify(pl => pl.LoadTeamLeads(_config.teamLeadsPath, _config), Times.Once);
//         }
//     }
// }
