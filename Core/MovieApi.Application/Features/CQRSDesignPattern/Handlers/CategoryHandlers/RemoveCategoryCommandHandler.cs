using Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    internal class RemoveCategoryCommandHandler
    {

        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.Id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }


    }
}
