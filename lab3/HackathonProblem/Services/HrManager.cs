using HackathonProblem.Models;

namespace HackathonProblem.Services
{
    public class HrManager
    {
        private readonly HackathonOptions _config;
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public HrManager(ITeamBuildingStrategy teamBuildingStrategy, HackathonOptions config)
        {
            _teamBuildingStrategy = teamBuildingStrategy;
            _config = config;
        }

        public List<Wishlist> GetWishlists(List<Employee> employees)
        {
            List<Wishlist> wishlists = new List<Wishlist>();
            foreach (var employee in employees)
            {
                wishlists.Add(employee.GetDefaultWishlist(_config));
            }
            return wishlists;
        }

        public List<Team> BuildTeams(List<Employee> juniors, List<Employee> teamLeads,
            List<Wishlist> juniorsWishlists, List<Wishlist> teamLeadsWishlists, HackathonOptions config)
        {
            return _teamBuildingStrategy.BuildTeams(juniors, teamLeads, juniorsWishlists, teamLeadsWishlists, config);
        }
    }
}
