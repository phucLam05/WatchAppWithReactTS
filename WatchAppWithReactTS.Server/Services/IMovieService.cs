using WatchAppWithReactTS.Server.Models.DTOs;
using WatchAppWithReactTS.Server.Models.Request;
using WatchAppWithReactTS.Server.Models.Response;

namespace WatchAppWithReactTS.Server.Services;

public interface IMovieService
{
    Task<BaseResponse<PaginatedResponse<MovieListItemDto>>> GetMoviesAsync(MovieFilterRequest filter);
    Task<BaseResponse<MovieDetailDto>> GetMovieByIdAsync(string id);
    Task<BaseResponse<MovieStreamDto>> GetMovieStreamAsync(string id);
}
