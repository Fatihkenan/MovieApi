using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{

    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;
        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Tags.Select(x => new GetTagQueryResult
            {
                Id = x.Id,
                Title = x.Title
            }).ToListAsync(cancellationToken);
            return result;

        }
    }
}
