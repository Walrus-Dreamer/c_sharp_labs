using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public interface ITeamBuildingStrategy
    {
        List<Pair> BuildTeams(List<Junior> juniors, List<TeamLead> teamLeads);
    }
}
