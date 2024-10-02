using Biblioteca.Application.Queries.Response.Book;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Book
{
    public class FindAllBooksRequest : IRequest<PagedResponse<FindAllBooksResponse>>
    {
        public string TitleSearch { get; set; } = string.Empty;
    }
}
