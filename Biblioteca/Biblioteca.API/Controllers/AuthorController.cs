using Biblioteca.Application.Commands.Request.Author;
using Biblioteca.Application.Queries.Request.Author;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindAllAuthorsRequest (), cancellationToken);
            return Ok(result);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindAuthorRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                //return NoContent();
                return Ok(result);
            return NotFound(result.Message);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            if (result.Succeeded)
                return StatusCode(201, result);
            return BadRequest(result.Message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                //return NoContent();
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteAuthorRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                //return NoContent();
                return Ok(result);
            return NotFound(result.Message);
        }

    }
}
