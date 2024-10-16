using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class ParticipantLoader
    {
        private int _nextJuniorId = 0;
        private int _nextTeamLeadId = 0;

        public List<Junior> LoadJuniors(string filePath, Config config)
        {
            return LoadParticipants<Junior>(filePath, line => new Junior(_nextJuniorId++, line, config));
        }

        public List<TeamLead> LoadTeamLeads(string filePath, Config config)
        {
            return LoadParticipants<TeamLead>(filePath, line => new TeamLead(_nextTeamLeadId++, line, config));
        }

        private List<T> LoadParticipants<T>(string filePath, Func<string, T> createParticipant) where T : HackathonParticipant
        {
            return File.ReadAllLines(filePath)
                   .Skip(1) // Пропускаем заголовок.
                   .Select(line => createParticipant(line.Split(';')[1])) // Нам нужны только имена с фамилиями.
                   .ToList();
        }
    }
}
