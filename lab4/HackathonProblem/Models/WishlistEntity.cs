namespace HackathonProblem.Models
{
    public class WishlistEntity
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public ParticipantEntity Participant { get; set; }
        public int PreferenceId { get; set; }
        public ParticipantEntity Preference { get; set; }
        public int Rank { get; set; }
    }
}