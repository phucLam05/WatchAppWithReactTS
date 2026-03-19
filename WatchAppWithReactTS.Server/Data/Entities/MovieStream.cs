namespace WatchAppWithReactTS.Server.Data.Entities;

public class MovieStream
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public required string StreamType { get; set; } = "HLS";
    public required string ManifestUrl { get; set; }
    public string? SpriteUrl { get; set; }

    public Movie? Movie { get; set; }
}
