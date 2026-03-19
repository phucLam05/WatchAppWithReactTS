using Microsoft.EntityFrameworkCore;
using WatchAppWithReactTS.Server.Data.Entities;

namespace WatchAppWithReactTS.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<MovieStream> MovieStreams { get; set; } = null!;
    public DbSet<Subtitle> Subtitles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Movie
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.ThumbnailUrl)
                  .IsRequired()
                  .HasMaxLength(500);

            entity.Property(e => e.CoverUrl)
                  .HasMaxLength(500);

            entity.Property(e => e.Rating)
                  .HasColumnType("decimal(3,1)");

            // 1-to-1 relationship with MovieStream
            entity.HasOne(m => m.MovieStream)
                  .WithOne(ms => ms.Movie)
                  .HasForeignKey<MovieStream>(ms => ms.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);

            // 1-to-Many relationship with Subtitles
            entity.HasMany(m => m.Subtitles)
                  .WithOne(s => s.Movie)
                  .HasForeignKey(s => s.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // MovieStream
        modelBuilder.Entity<MovieStream>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.StreamType)
                  .HasMaxLength(50)
                  .HasDefaultValue("HLS");

            entity.Property(e => e.ManifestUrl)
                  .IsRequired()
                  .HasMaxLength(500);

            entity.Property(e => e.SpriteUrl)
                  .HasMaxLength(500);
        });

        // Subtitle
        modelBuilder.Entity<Subtitle>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.LanguageCode)
                  .IsRequired()
                  .HasMaxLength(10);

            entity.Property(e => e.Label)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.SubtitleUrl)
                  .IsRequired()
                  .HasMaxLength(500);
        });
    }
}
