namespace Biblioteca.Application.Queries.Response.Book
{
    public class FindAllBooksResponse
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int YearPublication { get; set; } = 2000;
    }
}
