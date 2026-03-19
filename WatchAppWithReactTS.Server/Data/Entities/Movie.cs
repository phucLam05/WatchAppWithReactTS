namespace WatchAppWithReactTS.Server.Data.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string ThumbnailUrl { get; set; }
    public string? CoverUrl { get; set; }
    public int? ReleaseYear { get; set; }
    public int? DurationMinutes { get; set; }
    public decimal? Rating { get; set; }
    public string? Genres { get; set; }

    public MovieStream? MovieStream { get; set; }
    public ICollection<Subtitle> Subtitles { get; set; } = new List<Subtitle>();
}
