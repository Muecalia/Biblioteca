using Biblioteca.Application.Queries.Response.Author;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Author
{
    //public class FindAllAuthorsRequest : IRequest<PagedResponse<FindAllAuthorsResponse>>
    public class FindAuthorRequest : IRequest<ApiResponse<FindAuthorResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
