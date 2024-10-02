using Biblioteca.Application.Commands.Response.Author;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Author
{
    public class DeleteAuthorRequest : IRequest<ApiResponse<InputAuthorResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
