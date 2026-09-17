using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.UserRegisterCommand;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _registerHandler;
        public RegistersController(CreateUserRegisterCommandHandler registerHandler)
        {
            _registerHandler = registerHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRegisterCommand command)
        {
            try
            {
                await _registerHandler.Handle(command, CancellationToken.None);
                return Ok(new { message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
