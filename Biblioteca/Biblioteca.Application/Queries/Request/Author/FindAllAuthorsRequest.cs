using Biblioteca.Application.Queries.Response.Author;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Author
{
    public class FindAllAuthorsRequest : IRequest<PagedResponse<FindAllAuthorsResponse>>
    {
        public string NameSearch { get; set; } = string.Empty;
    }
}
