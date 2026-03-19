using WatchAppWithReactTS.Server.Models.DTOs;
using WatchAppWithReactTS.Server.Models.Request;
using WatchAppWithReactTS.Server.Models.Response;
using WatchAppWithReactTS.Server.Repositories;

namespace WatchAppWithReactTS.Server.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<BaseResponse<PaginatedResponse<MovieListItemDto>>> GetMoviesAsync(MovieFilterRequest filter)
    {
        var data = await _movieRepository.GetMoviesAsync(filter);
        return new BaseResponse<PaginatedResponse<MovieListItemDto>>
        {
            Success = true,
            Data = data
        };
    }

    public async Task<BaseResponse<MovieDetailDto>> GetMovieByIdAsync(string id)
    {
        var data = await _movieRepository.GetMovieByIdAsync(id);
        if (data == null)
        {
            return new BaseResponse<MovieDetailDto> { Success = false };
        }

        return new BaseResponse<MovieDetailDto>
        {
            Success = true,
            Data = data
        };
    }

    public async Task<BaseResponse<MovieStreamDto>> GetMovieStreamAsync(string id)
    {
        var data = await _movieRepository.GetMovieStreamAsync(id);
        if (data == null)
        {
            return new BaseResponse<MovieStreamDto> { Success = false };
        }

        return new BaseResponse<MovieStreamDto>
        {
            Success = true,
            Data = data
        };
    }
}
