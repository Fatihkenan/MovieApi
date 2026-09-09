using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries
{
    public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        public GetCastByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
