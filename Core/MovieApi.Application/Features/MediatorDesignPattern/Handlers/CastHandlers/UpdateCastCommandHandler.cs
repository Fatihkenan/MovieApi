using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _movieContext;
        public UpdateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _movieContext.Casts.FindAsync(request.Id, cancellationToken);
            if (cast != null)
            {
                cast.Title = request.Title;
                cast.Name = request.Name;
                cast.Surname = request.Surname;
                cast.ImageUrl = request.ImageUrl;
                cast.Overview = request.Overview;
                cast.Biography = request.Biography;
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
