namespace WatchAppWithReactTS.Server.Models.Response;

public class BaseResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
}

public class PaginatedResponse<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public PaginationMeta Pagination { get; set; } = new();
}

public class PaginationMeta
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int Limit { get; set; }
}
