using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommand;
using Persistence.Context;
using Persistence.Identity;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers
{
    public class CreateUserRegisterCommandHandler : IRequestHandler<CreateUserRegisterCommand, Unit>
    {
        private readonly MovieContext _context;
        private readonly UserManager<AppUser> _usermanager;
        public CreateUserRegisterCommandHandler(MovieContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }
        public async Task<Unit> Handle(CreateUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.Username,
                Email = request.Email
            };
            var result = await _usermanager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return Unit.Value;
        }

    }
}
