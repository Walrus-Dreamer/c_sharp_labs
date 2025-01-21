namespace HackathonProblem.Models
{
    public class ParticipantEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public ICollection<WishlistEntity> Wishlists { get; set; }
    }
}