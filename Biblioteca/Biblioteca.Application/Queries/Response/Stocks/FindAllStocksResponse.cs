namespace Biblioteca.Application.Queries.Response.Stocks
{
    public class FindAllStocksResponse
    {
        public int Id { get; set; } = 0;
        public string Book { get; set; } = string.Empty;
        public int QtdBooks { get; set; } = 0;
        public string User { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
    }
}
