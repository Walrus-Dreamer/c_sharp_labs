namespace HackathonProblem.Models
{
    public record class Hackathon(List<Team> teams, List<Wishlist> teamLeadsWishlists, List<Wishlist> juniorsWishlists);
}
