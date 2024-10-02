using System.Collections.Generic;
using HackathonApp.Models;

namespace HackathonApp.Services
{
    public class HrManager
    {
        private readonly ParticipantLoader _participantLoader;

        public HrManager(ParticipantLoader participantLoader)
        {
            _participantLoader = participantLoader;
        }

        public List<Junior> LoadJuniors()
        {
            return _participantLoader.LoadJuniors("../CSHARP_2024_NSU/Juniors20.csv");
        }

        public List<TeamLead> LoadTeamLeads()
        {
            return _participantLoader.LoadTeamLeads("../CSHARP_2024_NSU/TeamLeads20.csv");
        }
    }
}
