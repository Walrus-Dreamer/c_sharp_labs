using HackathonProblem.Services;
using HackathonProblem.Models;

namespace HackathonProblem.Tests
{
    public class EmployeeLoaderTests
    {
        private readonly EmployeeLoader _employeeLoader;
        private readonly HackathonOptions _config = new HackathonOptions();

        public EmployeeLoaderTests()
        {
            // Arrange.
            _employeeLoader = new EmployeeLoader();
            _config.hackathonCount = 10;
            _config.teamsCount = 40;
            _config.juniorsPath = "../../../../../CSHARP_2024_NSU/Juniors20.csv";
            _config.teamLeadsPath = "../../../../../CSHARP_2024_NSU/TeamLeads20.csv";
        }

        [Fact]
        public void LoadJuniors_ShouldLoadCorrectNumberOfJuniors()
        {
            // Act.
            LoadedEmployees loadedEmployees = _employeeLoader.LoadEmployees(_config);
            List<Employee> juniors = loadedEmployees.juniors;

            // Assert.
            Assert.Equal(20, juniors.Count);
            Assert.Equal("Юдин Адам", juniors[0].name);
            Assert.Equal("Яшина Яна", juniors[1].name);
        }

        [Fact]
        public void LoadTeamLeads_ShouldLoadCorrectNumberOfTeamLeads()
        {
            // Act.
            LoadedEmployees loadedEmployees = _employeeLoader.LoadEmployees(_config);
            List<Employee> teamLeads = loadedEmployees.teamLeads;

            // Assert.
            Assert.Equal(20, teamLeads.Count);
            Assert.Equal("Филиппова Ульяна", teamLeads[0].name);
            Assert.Equal("Николаев Григорий", teamLeads[1].name);
        }

        [Fact]
        public void LoadEmployees_ShouldThrowException_WhenEmployeesCountDoesNotMatchConfig()
        {
            // Arramge.
            _config.teamsCount = 1;

            // Act & Assert.
            Exception exception = Assert.Throws<Exception>(() =>
                _employeeLoader.LoadEmployees(_config));

            Assert.Equal("Wrong number of employees: 40 instead of 1", exception.Message);
        }
    }
}
