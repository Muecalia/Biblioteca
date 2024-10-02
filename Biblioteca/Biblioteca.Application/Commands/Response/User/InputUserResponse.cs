namespace Biblioteca.Application.Commands.Response.User
{
    public class InputUserResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string? Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
