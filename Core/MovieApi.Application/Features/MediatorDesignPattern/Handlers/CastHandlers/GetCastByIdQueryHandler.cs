using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _movieContext;
        public GetCastByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var cast = await _movieContext.Casts.FindAsync(request.Id, cancellationToken);
            return new GetCastByIdQueryResult
            {
                Id = cast.Id,
                Title = cast.Title,
                Name = cast.Name,
                Surname = cast.Surname,
                ImageUrl = cast.ImageUrl,
                Overview = cast.Overview,
                Biography = cast.Biography
            };
        }
    }
}
