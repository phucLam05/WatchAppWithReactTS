using WatchAppWithReactTS.Server.Models.DTOs;
using WatchAppWithReactTS.Server.Models.Request;
using WatchAppWithReactTS.Server.Models.Response;

namespace WatchAppWithReactTS.Server.Repositories;

public interface IMovieRepository
{
    Task<PaginatedResponse<MovieListItemDto>> GetMoviesAsync(MovieFilterRequest filter);
    Task<MovieDetailDto?> GetMovieByIdAsync(string id);
    Task<MovieStreamDto?> GetMovieStreamAsync(string id);
}
