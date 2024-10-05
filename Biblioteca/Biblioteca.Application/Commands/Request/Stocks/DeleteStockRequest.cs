using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Stocks
{
    public class DeleteStockRequest : IRequest<ApiResponse<InputStockResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
