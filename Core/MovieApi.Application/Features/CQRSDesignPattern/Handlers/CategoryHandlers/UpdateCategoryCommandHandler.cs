using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _context;
        public UpdateCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.Id);
            if (category != null)
            {
                category.Name = command.Name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
