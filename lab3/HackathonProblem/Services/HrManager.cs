using System.Collections.Generic;
using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrManager
    {
        private readonly ParticipantLoader _participantLoader;
        private readonly Config _config;
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public HrManager(ParticipantLoader participantLoader, ITeamBuildingStrategy teamBuildingStrategy, Config config)
        {
            this._participantLoader = participantLoader;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this._config = config;
        }

        public List<Junior> LoadJuniors()
        {
            return _participantLoader.LoadJuniors(this._config.juniorsPath, this._config);
        }

        public List<TeamLead> LoadTeamLeads()
        {
            return _participantLoader.LoadTeamLeads(this._config.teamLeadsPath, this._config);
        }

        public List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            return _teamBuildingStrategy.BuildTeams(juniors, teamLeads, this._config);
        }
    }
}
