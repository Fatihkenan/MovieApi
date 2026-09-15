using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class RemoveTagCommand : IRequest
    {
        public RemoveTagCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
