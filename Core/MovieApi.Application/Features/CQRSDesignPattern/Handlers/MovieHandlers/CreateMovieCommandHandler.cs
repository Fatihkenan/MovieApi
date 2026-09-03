using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Domain.Entities.Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                Description = command.Description,
                Duration = command.Duration,
                Status = command.Status,
                ReleaseDate = command.ReleaseDate,
                CreatedYear = command.CreatedYear,
                rating = command.Rating,
                Title = command.Title,
            });
            await _context.SaveChangesAsync();
        }
    }
}
