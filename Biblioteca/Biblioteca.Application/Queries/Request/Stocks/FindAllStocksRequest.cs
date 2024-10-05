using Biblioteca.Application.Queries.Response.Stocks;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Stocks
{
    public class FindAllStocksRequest : IRequest<PagedResponse<FindAllStocksResponse>>
    {
        public string Book { get; set; } = string.Empty;
    }
}
