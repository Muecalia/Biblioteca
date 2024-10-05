namespace Biblioteca.Application.Commands.Response.Stocks
{
    public class InputStockResponse
    {
        public int Id { get; set; } = 0;
        public string Book { get; set; } = string.Empty;
        public int QtdBooks { get; set; } = 0;
        public string User { get; set; } = string.Empty;
    }
}
