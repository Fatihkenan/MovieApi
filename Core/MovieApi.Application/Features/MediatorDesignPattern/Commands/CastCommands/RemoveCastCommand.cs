using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public RemoveCastCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
