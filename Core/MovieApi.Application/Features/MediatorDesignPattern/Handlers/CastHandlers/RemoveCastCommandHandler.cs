using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _movieContext;
        public RemoveCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _movieContext.Casts.FindAsync(request.Id, cancellationToken);
            if (cast != null)
            {
                _movieContext.Casts.Remove(cast);
                await _movieContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
