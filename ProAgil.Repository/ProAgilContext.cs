
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
  public class ProAgilContext : DbContext
  {
    public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<Event> Speakers { get; set; }
    public DbSet<Event> SpeakerEvents { get; set; }
    public DbSet<Event> Lots { get; set; }
    public DbSet<Event> SocialMedias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<SpeakerEvent>()
        .HasKey(PE => new { PE.EventId, PE.SpeakerId });
    }
  }
}