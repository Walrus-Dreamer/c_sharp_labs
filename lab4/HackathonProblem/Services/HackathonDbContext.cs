using HackathonProblem.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonProblem.Services
{
    public class HackathonDbContext : DbContext
    {
        public HackathonDbContext(DbContextOptions<HackathonDbContext> options) : base(options) { }

        public DbSet<HackathonEntity> Hackathons { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<ParticipantEntity> Participants { get; set; }
        public DbSet<WishlistEntity> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HackathonEntity>().HasKey(h => h.Id);
            modelBuilder.Entity<TeamEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<ParticipantEntity>().HasKey(p => p.Id);
            modelBuilder.Entity<WishlistEntity>().HasKey(w => w.Id);

            modelBuilder.Entity<WishlistEntity>()
                .HasOne(w => w.Participant)
                .WithMany(p => p.Wishlists)
                .HasForeignKey(w => w.ParticipantId);

            modelBuilder.Entity<TeamEntity>()
                .HasOne(t => t.TeamLead);

            modelBuilder.Entity<TeamEntity>()
                .HasOne(t => t.Junior);
        }
    }
}