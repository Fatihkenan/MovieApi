using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _mediator.Send(new GetTagQuery());
            return Ok(tags);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok(new { message = "Tag created successfully", StatusCode = 201 });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(tag);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok(new { message = "Tag deleted successfully", StatusCode = 200 });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, UpdateTagCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest(new { message = "Id in the URL does not match Id in the request body", StatusCode = 400 });
            }
            await _mediator.Send(command, cancellationToken);
            return Ok(new { message = "Tag updated successfully", StatusCode = 200 });
        }

    }
}
