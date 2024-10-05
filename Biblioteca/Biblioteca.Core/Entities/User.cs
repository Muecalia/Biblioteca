using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class User : IdentityUser
    {
        public User() 
        {
            Loans = [];
            IsActive = true;
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Profile { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
