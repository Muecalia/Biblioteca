using Biblioteca.Application.Queries.Response.Book;

namespace Biblioteca.Application.Queries.Response.Loan
{
    public class FindLoanResponse
    {
        public int Id { get; set; } = 0;
        public string User { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ExpectedReturnDate { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<FindAllBooksResponse> Books { get; set; } = [];
    }
}
