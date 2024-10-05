using Biblioteca.Application.Queries.Response.Stocks;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Stocks
{
    public class FindStockRequest : IRequest<ApiResponse<FindStockResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
