using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.Id);
            if (movie != null)
            {
                movie.Title = command.Title;
                movie.Description = command.Description;
                movie.ReleaseDate = command.ReleaseDate;
                movie.Duration = command.Duration;
                movie.CoverImageUrl = command.CoverImageUrl;
                movie.rating = command.rating;
                movie.CreatedYear = command.CreatedYear;
                movie.Status = command.Status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
