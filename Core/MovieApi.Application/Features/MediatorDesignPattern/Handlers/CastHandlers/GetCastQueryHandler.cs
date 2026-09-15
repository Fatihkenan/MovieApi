using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _movieContext;
        public GetCastQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var casts = await _movieContext.Casts.ToListAsync(cancellationToken);
            return casts.Select(c => new GetCastQueryResult
            {
                Id = c.Id,
                Title = c.Title,
                Name = c.Name,
                Surname = c.Surname,
                ImageUrl = c.ImageUrl,
                Overview = c.Overview,
                Biography = c.Biography
            }).ToList();
        }
    }
}
