using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class ParticipantLoader
    {
        private int _nextJuniorId = 0;
        private int _nextTeamLeadId = 0;

        public virtual List<Junior> LoadJuniors(string filePath, Config config)
        {
            return LoadParticipants<Junior>(filePath, line => new Junior(_nextJuniorId++, line, config), config);
        }

        public virtual List<TeamLead> LoadTeamLeads(string filePath, Config config)
        {
            return LoadParticipants<TeamLead>(filePath, line => new TeamLead(_nextTeamLeadId++, line, config), config);
        }

        private List<T> LoadParticipants<T>(string filePath, Func<string, T> createParticipant, Config config) where T : HackathonParticipant
        {
            List<T> result = File.ReadAllLines(filePath)
                   .Skip(1) // Пропускаем заголовок.
                   .Select(line => createParticipant(line.Split(';')[1])) // Нам нужны только имена с фамилиями.
                   .ToList();
            if (result.Count != config.teamsCount)
            {
                throw new Exception($"Wrong number of participants: {result.Count} instead of {config.teamsCount}");
            }

            return result;
        }
    }
}
