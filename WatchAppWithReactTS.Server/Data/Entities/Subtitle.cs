namespace WatchAppWithReactTS.Server.Data.Entities;

public class Subtitle
{
    public Guid Id { get; set; }
    public Guid MovieId { get; set; }
    public required string LanguageCode { get; set; }
    public required string Label { get; set; }
    public required string SubtitleUrl { get; set; }

    public Movie? Movie { get; set; }
}
