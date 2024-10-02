using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Users : BaseEntity
    {
        public Users() : base() { }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(50)]
        public string? Username { get; set; }
        [EmailAddress, Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100), PasswordPropertyText]
        public string Password { get; set; }
        public List<Loan> Loans { get; set; } = [];
    }
}
