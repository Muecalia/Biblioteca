using Biblioteca.Application.Commands.Response.Book;
using Biblioteca.Application.Wrappers;
using MediatR;

namespace Biblioteca.Application.Commands.Request.Book
{
    public class CreateBookRequest : IRequest<ApiResponse<InputBookResponse>>
    {
        public string Title { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int YearPublication { get; set; } = 2000;
        public string Summary { get; set; } = string.Empty;
        public List<int> IdAuthors { get; set; } = [];
    }
}
