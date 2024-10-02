using Biblioteca.Core.Enuns;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan() : base() 
        {
            Books = [];
            Status = LoanStatus.Pending;            
        }

        public int? IdUser { get; set; }
        public int? IdCustomer { get; set; }
        [MaxLength(500)]
        public string? Comment { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
        public Users? User { get; set; }
        public Customer? Customer { get; set; }
        public List<LoanBooks> Books { get; set; }
    }
}
