using Biblioteca.Core.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan() : base() 
        {
            Books = [];
            Status = LoanStatus.Borrowed;            
        }

        public string IdCustomer { get; set; }
        public string? IdEmployee { get; set; }
        [MaxLength(500)]
        public string? Comment { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
        public User Customer { get; set; }
        public User? Employee { get; set; }
        public List<LoanBooks> Books { get; set; }
    }
}
