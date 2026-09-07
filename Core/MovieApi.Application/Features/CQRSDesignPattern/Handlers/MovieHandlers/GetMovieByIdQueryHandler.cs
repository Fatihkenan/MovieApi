using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Result.MovieResults;
using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var movie = await _context.Movies.FindAsync(query.Id);
            return new GetMovieByIdQueryResult
            {
                Id = query.Id,
                Title = query.Title,
                CoverImageUrl = query.CoverImageUrl,
                rating = query.rating,
                Description = query.Description,
                Duration = query.Duration,
                ReleaseDate = query.ReleaseDate,
                CreatedYear = query.CreatedYear,
                Status = query.Status
            };
        }

    }
}
