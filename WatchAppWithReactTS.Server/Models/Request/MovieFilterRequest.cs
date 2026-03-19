namespace WatchAppWithReactTS.Server.Models.Request;

public class MovieFilterRequest
{
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 20;
    public string? Category { get; set; }
    public string? Sort { get; set; }
}
