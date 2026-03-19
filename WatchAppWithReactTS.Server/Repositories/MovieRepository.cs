using Microsoft.EntityFrameworkCore;
using WatchAppWithReactTS.Server.Data;
using WatchAppWithReactTS.Server.Models.DTOs;
using WatchAppWithReactTS.Server.Models.Request;
using WatchAppWithReactTS.Server.Models.Response;

namespace WatchAppWithReactTS.Server.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResponse<MovieListItemDto>> GetMoviesAsync(MovieFilterRequest filter)
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Category))
        {
            query = query.Where(m => m.Genres != null && m.Genres.Contains(filter.Category));
        }

        if (!string.IsNullOrEmpty(filter.Sort))
        {
            if (filter.Sort.Equals("latest", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(m => m.ReleaseYear);
            }
            else if (filter.Sort.Equals("popular", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(m => m.Rating);
            }
        }

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)filter.Limit);

        var movies = await query
            .Skip((filter.Page - 1) * filter.Limit)
            .Take(filter.Limit)
            .Select(m => new MovieListItemDto
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                ThumbnailUrl = m.ThumbnailUrl,
                ReleaseYear = m.ReleaseYear ?? 0,
                DurationMinutes = m.DurationMinutes ?? 0,
                Genres = string.IsNullOrEmpty(m.Genres) ? new List<string>() : m.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                Rating = m.Rating.HasValue ? (double)m.Rating.Value : 0.0
            })
            .ToListAsync();

        return new PaginatedResponse<MovieListItemDto>
        {
            Items = movies,
            Pagination = new PaginationMeta
            {
                CurrentPage = filter.Page,
                Limit = filter.Limit,
                TotalItems = totalItems,
                TotalPages = totalPages
            }
        };
    }

    public async Task<MovieDetailDto?> GetMovieByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return null;
        }

        var movie = await _context.Movies
            .Include(m => m.MovieStream)
            .Where(m => m.Id == guidId)
            .Select(m => new MovieDetailDto
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Description = m.Description,
                CoverUrl = m.CoverUrl,
                ReleaseYear = m.ReleaseYear ?? 0,
                DurationMinutes = m.DurationMinutes ?? 0,
                Director = null, // In a larger schema, could map from Movie entity
                Cast = new List<string>(), // Handled similarly
                Genres = string.IsNullOrEmpty(m.Genres) ? new List<string>() : m.Genres.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(),
                Rating = m.Rating.HasValue ? (double)m.Rating.Value : 0.0,
                IsAvailableInHD = m.MovieStream != null
            })
            .FirstOrDefaultAsync();

        return movie;
    }

    public async Task<MovieStreamDto?> GetMovieStreamAsync(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return null;
        }

        var stream = await _context.MovieStreams
            .Include(ms => ms.Movie!)
                .ThenInclude(m => m.Subtitles)
            .Where(ms => ms.MovieId == guidId)
            .Select(ms => new MovieStreamDto
            {
                MovieId = ms.MovieId.ToString(),
                StreamType = ms.StreamType,
                ManifestUrl = ms.ManifestUrl,
                Subtitles = ms.Movie!.Subtitles.Select(s => new SubtitleDto
                {
                    Language = s.LanguageCode,
                    Label = s.Label,
                    Url = s.SubtitleUrl
                }).ToList(),
                ThumbnailSprites = ms.SpriteUrl
            })
            .FirstOrDefaultAsync();

        return stream;
    }
}
