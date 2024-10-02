using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

public class Junior : HackathonParticipant
{
    public Junior(string name) : base(name) { }
}

public class TeamLead : HackathonParticipant
{
    public TeamLead(string name) : base(name) { }
}

public class Pair
{
    public int TeamLeadId { get; set; }
    public int JuniorId { get; set; }

    public Pair(int teamLeadId, int juniorId)
    {
        TeamLeadId = teamLeadId;
        JuniorId = juniorId;
    }
}

public class Hackathon
{
    public List<Junior> Juniors { get; set; }
    public List<TeamLead> TeamLeads { get; set; }
    public List<Pair> Team { get; set; }

    public Hackathon(string juniorsFile, string teamLeadsFile)
    {
        this.Juniors = LoadParticipants<Junior>(juniorsFile, line => new Junior(line));
        this.TeamLeads = LoadParticipants<TeamLead>(teamLeadsFile, line => new TeamLead(line));
        this.Team = GenerateRandomTeam();
        this.GenerateWishlists();
    }

    private List<T> LoadParticipants<T>(string filePath, Func<string, T> createParticipant)
    {
        return File.ReadAllLines(filePath)
                   .Skip(1) // Skip header.
                   .Select(line => createParticipant(line.Split(';')[1])) // We need only names with surnames.
                   .ToList();
    }

    private List<Pair> GenerateRandomTeam()
    {
        Random random = new Random();
        var indices = Enumerable.Range(0, Juniors.Count).ToList();
        indices = indices.OrderBy(x => random.Next()).ToList();

        var Team = new List<Pair>();
        for (int i = 0; i < Juniors.Count; i++)
        {
            Team.Add(new Pair(i, indices[i]));
        }

        return Team;
    }

    private void GenerateWishlists()
    {
        int juniorCount = this.TeamLeads.Count;
        int teamLeadCount = this.Juniors.Count;

        Action<List<HackathonParticipant>, int> generateWishlist = (participants, count) =>
        {
            foreach (var participant in participants)
            {
                participant.Wishlist = GenerateRandomList(0, count - 1);
            }
        };

        generateWishlist(this.Juniors.Cast<HackathonParticipant>().ToList(), teamLeadCount);
        generateWishlist(this.TeamLeads.Cast<HackathonParticipant>().ToList(), juniorCount);
    }

    private List<int> GenerateRandomList(int min, int max)
    {
        Random random = new Random();
        return Enumerable.Range(min, max + 1).OrderBy(x => random.Next()).ToList();
    }

    public double CalculateHarmonicity()
    {
        double totalSatisfaction = 0;

        foreach (var pair in Team)
        {
            int juniorSatisfaction = 20 - Juniors[pair.JuniorId].Wishlist[pair.TeamLeadId];
            int teamLeadSatisfaction = 20 - TeamLeads[pair.TeamLeadId].Wishlist[pair.JuniorId];

            totalSatisfaction += (2.0 * juniorSatisfaction * teamLeadSatisfaction) /
                                (juniorSatisfaction + teamLeadSatisfaction);
        }

        return totalSatisfaction / Juniors.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        double totalHarmonicity = 0;
        int hackathonCount = 1000;

        for (int i = 0; i < hackathonCount; i++)
        {
            var hackathon = new Hackathon("../CSHARP_2024_NSU/Juniors20.csv", "../CSHARP_2024_NSU/TeamLeads20.csv");
            double harmonicity = hackathon.CalculateHarmonicity();
            totalHarmonicity += harmonicity;
            Console.WriteLine($"Hackathon {i + 1}: Harmonicity = {harmonicity:F2}");
        }

        Console.WriteLine($"Average Harmonicity: {totalHarmonicity / hackathonCount:F2}");
    }
}
