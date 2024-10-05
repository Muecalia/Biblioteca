namespace Biblioteca.Application.Commands.Response.Loan
{
    public class UpdateLoanResponse
    {
        public int Id { get; set; } = 0;
        public int QtdBooks { get; set; } = 0;
        public string Employee { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
    }
}
