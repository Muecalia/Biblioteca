using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book() : base()
        {
            Loans = [];
            Authors = [];
        }

        [MaxLength(100), Required]
        public string Title { get; set; }
        [MaxLength(10), Required]
        public string BarCode { get; set; }
        [MaxLength(30), Required]
        public string ISBN { get; set; }
        [Required]
        public int YearPublication { get; set; }
        [MaxLength(500)]
        public string? Summary { get; set; }
        public List<LoanBooks> Loans { get; set; }
        public List<AuthorBooks> Authors { get; set; }
    }
}
