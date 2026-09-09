using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    internal class GetCastQueryHandler : IRequestHandler<GetCastQuery, GetCastQueryResult>
    {
    }
}
