using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Result.MovieResults;
using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(m => new GetMovieQueryResult
            {
                Id = m.Id,
                Title = m.Title,
                CoverImageUrl = m.CoverImageUrl,
                rating = m.rating,
                Description = m.Description,
                Duration = m.Duration,
                ReleaseDate = m.ReleaseDate,
                CreatedYear = m.CreatedYear,
                Status = m.Status
            }).ToList();
        }
    }
}
