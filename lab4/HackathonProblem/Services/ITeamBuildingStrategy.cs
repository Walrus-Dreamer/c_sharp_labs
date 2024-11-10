using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public interface ITeamBuildingStrategy
    {
        List<Team> BuildTeams(List<Employee> teamLeads, List<Employee> juniors,
            List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists, HackathonOptions config);
    }
}
