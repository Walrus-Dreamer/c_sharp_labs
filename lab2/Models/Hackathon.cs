using HackathonApp.Services;
using System;
using System.Collections.Generic;

namespace HackathonApp.Models
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; set; }
        public List<TeamLead> TeamLeads { get; set; }
        public List<Pair> Team { get; set; }
        private readonly ITeamBuildingStrategy _teamBuildingStrategy;

        public Hackathon(List<Junior> juniors, List<TeamLead> teamLeads, ITeamBuildingStrategy teamBuildingStrategy)
        {
            this.Juniors = juniors;
            this.TeamLeads = teamLeads;
            this._teamBuildingStrategy = teamBuildingStrategy;
            this.Team = _teamBuildingStrategy.BuildTeams(juniors, teamLeads);
            this.GenerateWishlists();
        }

        private List<int> GenerateRandomList(int min, int max)
        {
            Random random = new Random();
            return new List<int>(Enumerable.Range(min, max).OrderBy(x => random.Next()));
        }

        private void GenerateWishlists()
        {
            int juniorCount = this.TeamLeads.Count;
            int teamLeadCount = this.Juniors.Count;

            Action<List<HackathonParticipant>, int> generateWishlist = (participants, count) =>
            {
                foreach (var participant in participants)
                {
                    participant.Wishlist = this.GenerateRandomList(1, count);
                }
            };

            generateWishlist(this.Juniors.ConvertAll(x => (HackathonParticipant)x), teamLeadCount);
            generateWishlist(this.TeamLeads.ConvertAll(x => (HackathonParticipant)x), juniorCount);
        }
    }
}
