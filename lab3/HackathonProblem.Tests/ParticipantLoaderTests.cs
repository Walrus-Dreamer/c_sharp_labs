using HackathonProblem.Services;
using HackathonProblem.Models;

namespace HackathonProblem.Tests
{
    public class ParticipantLoaderTests
    {
        private readonly ParticipantLoader _participantLoader;
        private readonly Config _config = new Config(10, 2, "../../../../../CSHARP_2024_NSU/Juniors20.csv", "../../../../../CSHARP_2024_NSU/TeamLeads20.csv");

        public ParticipantLoaderTests()
        {
            _participantLoader = new ParticipantLoader();
        }

        [Fact]
        public void LoadJuniors_ShouldLoadCorrectNumberOfJuniors()
        {
            // Arrange.
            string filePath = "test_juniors.txt";
            string fileData = "Header\n1;John Doe\n2;Jane Smith";
            File.WriteAllText(filePath, fileData);

            // Act.
            List<Junior> juniors = _participantLoader.LoadJuniors(filePath, _config);

            // Assert.
            Assert.Equal(2, juniors.Count);
            Assert.Equal("John Doe", juniors[0].Name);
            Assert.Equal("Jane Smith", juniors[1].Name);

            // Cleanup.
            File.Delete(filePath);
        }

        [Fact]
        public void LoadTeamLeads_ShouldLoadCorrectNumberOfTeamLeads()
        {
            // Arrange.
            string filePath = "test_teamleads.txt";
            string fileData = "Header\n1;Alice Cooper\n2;Bob Marley";
            File.WriteAllText(filePath, fileData);

            // Act.
            List<TeamLead> teamLeads = _participantLoader.LoadTeamLeads(filePath, _config);

            // Assert.
            Assert.Equal(2, teamLeads.Count);
            Assert.Equal("Alice Cooper", teamLeads[0].Name);
            Assert.Equal("Bob Marley", teamLeads[1].Name);

            // Cleanup.
            File.Delete(filePath);
        }

        [Fact]
        public void LoadJuniors_ShouldThrowException_WhenParticipantsCountDoesNotMatchConfig()
        {
            // Arrange.
            string filePath = "test_juniors_invalid.txt";
            string fileData = "Header\n1;John Doe";
            File.WriteAllText(filePath, fileData);

            // Act & Assert.
            Exception exception = Assert.Throws<Exception>(() =>
                _participantLoader.LoadJuniors(filePath, _config));

            Assert.Equal("Wrong number of participants: 1 instead of 2", exception.Message);

            // Cleanup.
            File.Delete(filePath);
        }

        [Fact]
        public void LoadTeamLeads_ShouldThrowException_WhenParticipantsCountDoesNotMatchConfig()
        {
            // Arrange.
            string filePath = "test_teamleads_invalid.txt";
            string fileData = "Header\n1;Alice Cooper";
            File.WriteAllText(filePath, fileData);

            // Act & Assert.
            Exception exception = Assert.Throws<Exception>(() =>
                _participantLoader.LoadTeamLeads(filePath, _config));

            Assert.Equal("Wrong number of participants: 1 instead of 2", exception.Message);

            // Cleanup.
            File.Delete(filePath);
        }
    }
}
