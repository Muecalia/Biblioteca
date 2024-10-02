using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Author : BaseEntity
    {
        public Author() : base() 
        {
            Books = [];
        }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        [EmailAddress, MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        public List<AuthorBooks> Books { get; set; }
    }
}
