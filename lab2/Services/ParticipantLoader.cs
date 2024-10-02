using System;
using System.Collections.Generic;
using System.IO;
using HackathonApp.Models;

namespace HackathonApp.Services
{
    public class ParticipantLoader
    {
        public List<Junior> LoadJuniors(string filePath)
        {
            return LoadParticipants<Junior>(filePath, line => new Junior(line));
        }

        public List<TeamLead> LoadTeamLeads(string filePath)
        {
            return LoadParticipants<TeamLead>(filePath, line => new TeamLead(line));
        }

        private List<T> LoadParticipants<T>(string filePath, Func<string, T> createParticipant) where T : HackathonParticipant
        {
            var participants = new List<T>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var columns = line.Split(';');
                var name = columns[1];
                participants.Add(createParticipant(name));
            }

            return participants;
        }
    }
}
