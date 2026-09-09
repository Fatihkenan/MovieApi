using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public RemoveCastCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }

    }
}
