using Biblioteca.Application.Commands.Response.Stocks;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Stocks
{
    public class UpdateStockRequest : IRequest<ApiResponse<InputStockResponse>>
    {
        public int Id { get; set; } = 0;
        public int QtdBooks { get; set; } = 0;
        public string IdUser { get; set; } = string.Empty;
    }
}
