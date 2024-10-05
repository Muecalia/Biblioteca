namespace Biblioteca.Application.Commands.Response.Loan
{
    public class InputLoanResponse
    {
        public int Id { get; set; } = 0;
        public int QtdBooks { get; set; } = 0;
        public string Customer { get; set; } = string.Empty;
        public string ExpectedReturnDate { get; set; } = string.Empty;
    }
}
