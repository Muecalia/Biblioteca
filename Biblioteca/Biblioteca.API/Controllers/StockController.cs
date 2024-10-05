using Biblioteca.Application.Commands.Request.Stocks;
using Biblioteca.Application.Queries.Request.Stocks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindAllStocksRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindStockRequest { Id = Id}, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result.Message);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteStockRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStockRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return StatusCode(201, result);
            return BadRequest(result.Message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateStockRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
