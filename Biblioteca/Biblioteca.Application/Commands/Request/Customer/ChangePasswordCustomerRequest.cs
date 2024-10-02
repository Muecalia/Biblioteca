namespace Biblioteca.Application.Commands.Request.Customer
{
    public class ChangePasswordCustomerRequest
    {
        public int Id { get; set; } = 0;
        public string NewPassword { get; set; } = string.Empty;
    }
}
