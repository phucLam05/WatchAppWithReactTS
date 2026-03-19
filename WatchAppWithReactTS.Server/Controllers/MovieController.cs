using Microsoft.AspNetCore.Mvc;
using WatchAppWithReactTS.Server.Models.Request;
using WatchAppWithReactTS.Server.Services;

namespace WatchAppWithReactTS.Server.Controllers;

[ApiController]
[Route("api/v1/movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovies([FromQuery] MovieFilterRequest filter)
    {
        var result = await _movieService.GetMoviesAsync(filter);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(string id)
    {
        var result = await _movieService.GetMovieByIdAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("{id}/stream")]
    public async Task<IActionResult> GetMovieStream(string id)
    {
        var result = await _movieService.GetMovieStreamAsync(id);
        if (!result.Success)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}
