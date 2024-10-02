using Biblioteca.Application.Commands.Response.Author;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Author
{
    public class UpdateAuthorRequest : IRequest<ApiResponse<InputAuthorResponse>>
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
