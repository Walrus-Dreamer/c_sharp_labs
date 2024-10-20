// using System.Collections.Generic;
// using Xunit;
// using HackathonProblem.Models;
// using HackathonProblem.Services;

// namespace HackathonProblem.Tests
// {
//     public class HrDirectorTests
//     {
//         [Fact]
//         public void CalculateHarmonicity_ShouldReturnCorrectValue_ForValidInput()
//         {
//             // Arrange.
//             var hrDirector = new HrDirector();
//             var juniors = new List<Junior>
//             {
//                 new Junior { Name = "Junior 1" },
//                 new Junior { Name = "Junior 2" }
//             };

//             var teamLeads = new List<TeamLead>
//             {
//                 new TeamLead { Name = "TeamLead 1" },
//                 new TeamLead { Name = "TeamLead 2" }
//             };

//             var pairs = new List<Pair>
//             {
//                 new Pair { JuniorSatisfaction = 4, TeamLeadSatisfaction = 5 },
//                 new Pair { JuniorSatisfaction = 3, TeamLeadSatisfaction = 4 }
//             };

//             var config = new Config { teamsCount = 2 };

//             double expectedHarmonicity = 2 * 2 / (1.0 / 4 + 1.0 / 5 + 1.0 / 3 + 1.0 / 4);

//             // Act.
//             double result = hrDirector.CalculateHarmonicity(juniors, teamLeads, pairs, config);

//             // Assert.
//             Assert.Equal(expectedHarmonicity, result, precision: 6);
//         }

//         [Fact]
//         public void CalculateHarmonicity_ShouldHandleEmptyPairsList()
//         {
//             // Arrange.
//             var hrDirector = new HrDirector();
//             var juniors = new List<Junior>
//             {
//                 new Junior { Name = "Junior 1" },
//                 new Junior { Name = "Junior 2" }
//             };

//             var teamLeads = new List<TeamLead>
//             {
//                 new TeamLead { Name = "TeamLead 1" },
//                 new TeamLead { Name = "TeamLead 2" }
//             };

//             var pairs = new List<Pair>();
//             var config = new Config { teamsCount = 2 };

//             // Act & Assert.
//             Assert.Throws<System.DivideByZeroException>(() =>
//                 hrDirector.CalculateHarmonicity(juniors, teamLeads, pairs, config));
//         }

//         [Fact]
//         public void CalculateHarmonicity_ShouldReturnInfinity_ForZeroSatisfaction()
//         {
//             // Arrange.
//             var hrDirector = new HrDirector();
//             var juniors = new List<Junior>
//             {
//                 new Junior { Name = "Junior 1" },
//                 new Junior { Name = "Junior 2" }
//             };

//             var teamLeads = new List<TeamLead>
//             {
//                 new TeamLead { Name = "TeamLead 1" },
//                 new TeamLead { Name = "TeamLead 2" }
//             };

//             var pairs = new List<Pair>
//             {
//                 new Pair { JuniorSatisfaction = 0, TeamLeadSatisfaction = 5 },
//                 new Pair { JuniorSatisfaction = 3, TeamLeadSatisfaction = 0 }
//             };

//             var config = new Config { teamsCount = 2 };

//             // Act.
//             double result = hrDirector.CalculateHarmonicity(juniors, teamLeads, pairs, config);

//             // Assert.
//             Assert.True(double.IsInfinity(result));
//         }
//     }
// }
