namespace HackathonProblem.Models
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public int HackathonId { get; set; }
        public HackathonEntity Hackathon { get; set; }
        public ParticipantEntity TeamLead { get; set; }
        public ParticipantEntity Junior { get; set; }
    }
}