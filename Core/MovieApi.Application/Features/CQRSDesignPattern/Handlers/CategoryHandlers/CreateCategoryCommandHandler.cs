using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public CreateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Domain.Entities.Category { Name = command.Name });
            await _context.SaveChangesAsync();
        }

    }
}
