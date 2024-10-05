using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Stocks
{
    public class CreateStockRequest : IRequest<ApiResponse<InputStockResponse>>
    {
        public int IdBook { get; set; } = 0;
        public int QtdBooks { get; set; } = 0;
        public string IdUser { get; set; } = string.Empty;
    }
}
