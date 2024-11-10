namespace HackathonProblem.Models
{
    public record Employee(int id, string name)
    {
        public Wishlist GetRandomWishlist(HackathonOptions config)
        {
            Random random = new Random();
            int[] randomTeams = Enumerable.Range(1, config.teamsCount + 1)
                                          .OrderBy(x => random.Next())
                                          .ToArray();
            return new Wishlist(this.id, randomTeams);
        }

        public Wishlist GetDefaultWishlist(HackathonOptions config)
        {
            int[] defaultTeams = Enumerable.Range(1, config.teamsCount + 1).ToArray();
            return new Wishlist(this.id, defaultTeams);
        }
    }
}
