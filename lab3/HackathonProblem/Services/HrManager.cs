using System.Collections.Generic;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrManager
    {
        private readonly ParticipantLoader _participantLoader;
        private readonly Config _config;

        public HrManager(ParticipantLoader participantLoader, Config config)
        {
            this._participantLoader = participantLoader;
            this._config = config;
        }

        public List<Junior> LoadJuniors()
        {
            return _participantLoader.LoadJuniors(this._config.JuniorsPath);
        }

        public List<TeamLead> LoadTeamLeads()
        {
            return _participantLoader.LoadTeamLeads(this._config.TeamLeadsPath);
        }
    }
}
