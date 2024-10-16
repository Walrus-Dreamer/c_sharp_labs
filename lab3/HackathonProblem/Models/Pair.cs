namespace HackathonProblem.Models
{
    public class Pair
    {
        public TeamLead teamLead { get; set; }
        public int TeamLeadSatisfaction { get; set; }
        public Junior junior { get; set; }
        public int JuniorSatisfaction { get; set; }

        public Pair(TeamLead teamLead, Junior junior, Config config)
        {
            this.teamLead = teamLead;
            this.TeamLeadSatisfaction = 1;
            this.junior = junior;
            this.JuniorSatisfaction = 1;
        }
    }
}
