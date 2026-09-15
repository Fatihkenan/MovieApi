using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieContext _context;
        public RemoveTagCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(request.Id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
