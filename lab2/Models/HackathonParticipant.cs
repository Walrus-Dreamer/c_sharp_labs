using System.Collections.Generic;

namespace HackathonApp.Models
{
    public abstract class HackathonParticipant
    {
        public string Name { get; set; } // TODO: private
        public List<int> Wishlist { get; set; } // TODO: private

        protected HackathonParticipant(string name)
        {
            Name = name;
            Wishlist = new List<int>();
        }
    }
}
