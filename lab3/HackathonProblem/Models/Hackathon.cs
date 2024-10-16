using HackathonProblem.Services;
using System;
using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public class Hackathon
    {
        public List<Junior> juniors { get; set; }
        public List<TeamLead> teamLeads { get; set; }
        public List<Pair> team { get; set; }
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public Hackathon(List<Junior> juniors, List<TeamLead> teamLeads, ITeamBuildingStrategy teamBuildingStrategy, Config config)
        {
            this.juniors = juniors;
            this.teamLeads = teamLeads;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this.team = _teamBuildingStrategy.BuildTeams(juniors, teamLeads, config);
            this.GenerateWishlists();
        }

        private List<int> GenerateRandomList(int min, int max)
        {
            Random random = new Random();
            return new List<int>(Enumerable.Range(min, max).OrderBy(x => random.Next()));
        }

        private void GenerateWishlists()
        {
            int juniorCount = this.teamLeads.Count;
            int teamLeadCount = this.juniors.Count;

            Action<List<HackathonParticipant>, int> generateWishlist = (participants, count) =>
            {
                foreach (var participant in participants)
                {
                    participant.Wishlist = this.GenerateRandomList(1, count);
                }
            };

            generateWishlist(this.juniors.ConvertAll(x => (HackathonParticipant)x), teamLeadCount);
            generateWishlist(this.teamLeads.ConvertAll(x => (HackathonParticipant)x), juniorCount);
        }
    }
}
