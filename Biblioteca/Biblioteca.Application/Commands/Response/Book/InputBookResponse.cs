namespace Biblioteca.Application.Commands.Response.Book
{
    public class InputBookResponse
    {
        public int Id { get; set; } = 0;
        public int YearPublication { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string OperationDate { get; set; } = string.Empty;
    }
}
