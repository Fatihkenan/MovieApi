using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Result.CategoryResult;
using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;
        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories.Select(c => new GetCategoryQueryResult
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
