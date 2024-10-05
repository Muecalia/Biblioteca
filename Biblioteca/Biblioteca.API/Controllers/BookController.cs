using Biblioteca.Application.Commands.Request.Book;
using Biblioteca.Application.Queries.Request.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindAllBooksRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("findById/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindBookRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded) 
                return StatusCode(201, result);
            return BadRequest(result.Message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateBookRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteBookRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}
