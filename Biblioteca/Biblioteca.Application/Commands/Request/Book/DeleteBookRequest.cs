using Biblioteca.Application.Commands.Response.Book;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Book
{
    public class DeleteBookRequest : IRequest<ApiResponse<InputBookResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
