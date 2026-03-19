namespace WatchAppWithReactTS.Server.Models.DTOs;

public class MovieListItemDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? ThumbnailUrl { get; set; }
    public int ReleaseYear { get; set; }
    public int DurationMinutes { get; set; }
    public List<string> Genres { get; set; } = [];
    public double Rating { get; set; }
}

public class MovieDetailDto
{
    public required string Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? CoverUrl { get; set; }
    public int ReleaseYear { get; set; }
    public int DurationMinutes { get; set; }
    public string? Director { get; set; }
    public List<string> Cast { get; set; } = [];
    public List<string> Genres { get; set; } = [];
    public double Rating { get; set; }
    public bool IsAvailableInHD { get; set; }
}

public class MovieStreamDto
{
    public required string MovieId { get; set; }
    public required string StreamType { get; set; }
    public required string ManifestUrl { get; set; }
    public List<SubtitleDto> Subtitles { get; set; } = [];
    public string? ThumbnailSprites { get; set; }
}

public class SubtitleDto
{
    public required string Language { get; set; }
    public required string Label { get; set; }
    public required string Url { get; set; }
}
