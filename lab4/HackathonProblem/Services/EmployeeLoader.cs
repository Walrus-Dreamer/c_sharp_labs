using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public record LoadedEmployees(List<Employee> teamLeads, List<Employee> juniors);

    public class EmployeeLoader
    {
        private List<Employee> LoadEmployeeList(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Skip(1) // Skip header.
                .Select(line =>
                {
                    var parts = line.Split(';');
                    if (parts.Length < 2)
                        throw new FormatException($"Bad line: {line}. Expected at least 2 parts.");

                    if (!int.TryParse(parts[0], out var id))
                        throw new FormatException($"Bad id: {parts[0]}. Expected integer.");

                    return new Employee(id, parts[1]);
                })
                .ToList();
        }

        public LoadedEmployees LoadEmployees(HackathonOptions config)
        {
            var teamLeads = LoadEmployeeList(config.teamLeadsPath);
            var juniors = LoadEmployeeList(config.juniorsPath);

            if (teamLeads.Count + juniors.Count != config.teamsCount * 2)
            {
                throw new Exception($"Wrong number of employees: {teamLeads.Count + juniors.Count} instead of {config.teamsCount * 2}");
            }

            return new LoadedEmployees(teamLeads, juniors);
        }
    }
}
