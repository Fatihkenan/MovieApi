using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class CreateTagCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
