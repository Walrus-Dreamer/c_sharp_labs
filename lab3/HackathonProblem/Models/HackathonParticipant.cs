using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public abstract class HackathonParticipant
    {
        public string Name { get; set; }
        public List<int> Wishlist { get; set; }

        protected HackathonParticipant(string name)
        {
            Name = name;
            Wishlist = new List<int>();
        }
    }
}
