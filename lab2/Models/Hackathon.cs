using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackathonApp.Models
{
    public class Hackathon
    {
        public List<Junior> Juniors { get; set; }
        public List<TeamLead> TeamLeads { get; set; }
        public List<Pair> Pairs { get; set; }

        public Hackathon(string juniorsFile, string teamLeadsFile)
        {
            Juniors = LoadParticipants<Junior>(juniorsFile, line => new Junior(line));
            TeamLeads = LoadParticipants<TeamLead>(teamLeadsFile, line => new TeamLead(line));
            Pairs = GenerateRandomPairs();
            GenerateWishlists();
        }

        private List<T> LoadParticipants<T>(string filePath, Func<string, T> createParticipant)
        {
            return File.ReadAllLines(filePath)
                       .Skip(1)
                       .Select(line => createParticipant(line.Split(';')[1]))
                       .ToList();
        }

        private List<Pair> GenerateRandomPairs()
        {
            Random random = new Random();
            var indices = Enumerable.Range(0, Juniors.Count).ToList();
            indices = indices.OrderBy(x => random.Next()).ToList();

            var pairs = new List<Pair>();
            for (int i = 0; i < Juniors.Count; i++)
            {
                pairs.Add(new Pair(i, indices[i]));
            }

            return pairs;
        }

        private void GenerateWishlists()
        {
            int juniorCount = TeamLeads.Count;
            int teamLeadCount = Juniors.Count;

            Action<List<HackathonParticipant>, int> generateWishlist = (participants, count) =>
            {
                foreach (var participant in participants)
                {
                    participant.Wishlist = GenerateRandomList(0, count - 1);
                }
            };

            generateWishlist(Juniors.Cast<HackathonParticipant>().ToList(), teamLeadCount);
            generateWishlist(TeamLeads.Cast<HackathonParticipant>().ToList(), juniorCount);
        }

        private List<int> GenerateRandomList(int min, int max)
        {
            Random random = new Random();
            return Enumerable.Range(min, max + 1).OrderBy(x => random.Next()).ToList();
        }

        public double CalculateHarmonicity()
        {
            double totalSatisfaction = 0;

            foreach (var pair in Pairs)
            {
                int juniorSatisfaction = 20 - Juniors[pair.JuniorId].Wishlist[pair.TeamLeadId];
                int teamLeadSatisfaction = 20 - TeamLeads[pair.TeamLeadId].Wishlist[pair.JuniorId];

                totalSatisfaction += (2.0 * juniorSatisfaction * teamLeadSatisfaction) /
                                    (juniorSatisfaction + teamLeadSatisfaction);
            }

            return totalSatisfaction / Juniors.Count;
        }
    }
}
