using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public abstract class HackathonParticipant
    {
        public int id { get; set; }
        private string Name { get; set; }
        public List<int> Wishlist { get; set; }

        protected HackathonParticipant(int id, string name, Config config)
        {
            this.id = id;
            this.Name = name;
            this.Wishlist = SetDefaultWishlist(config);
        }

        public List<int> SetRandomWishlist(Config config)
        {
            Random random = new Random();
            return new List<int>(Enumerable.Range(0, config.teamsCount).OrderBy(x => random.Next()));
        }

        private List<int> SetDefaultWishlist(Config config)
        {
            return new List<int>(Enumerable.Range(0, config.teamsCount));
        }
    }
}
