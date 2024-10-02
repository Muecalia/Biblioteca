using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer() : base() { }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress, Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required, MaxLength(100), PasswordPropertyText]
        public string Password { get; set; }
        public List<Loan> Loans { get; set; } = [];
    }
}
