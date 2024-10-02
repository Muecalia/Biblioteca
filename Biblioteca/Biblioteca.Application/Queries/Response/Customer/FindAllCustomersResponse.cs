namespace Biblioteca.Application.Queries.Response.Customer
{
    public class FindAllCustomersResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
    }
}
