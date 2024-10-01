using HackathonApp.Models;

namespace HackathonApp.Services
{
    public interface ITeamBuildingStrategy
    {
        List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
