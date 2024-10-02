using Biblioteca.Application.Queries.Response.Book;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Queries.Request.Book
{
    public class FindBookRequest : IRequest<ApiResponse<FindBookResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
