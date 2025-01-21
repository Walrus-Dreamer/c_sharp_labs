using System.Collections.Generic;

namespace HackathonProblem.Models
{
    public class HackathonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeamEntity> Teams { get; set; }
        public double HarmonyScore { get; set; }
    }
}