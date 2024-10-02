namespace Biblioteca.Application.Queries.Response.Book
{
    public class FindBookResponse
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int YearPublication { get; set; } = 2000;
        public string Summary { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = [];
    }
}
