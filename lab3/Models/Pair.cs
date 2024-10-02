namespace HackathonApp.Models
{
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
}
