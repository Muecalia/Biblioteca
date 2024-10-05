namespace Biblioteca.Core.Entities
{
    public class LoanBooks : BaseEntity
    {
        public LoanBooks() : base() { }

        public int? IdLoan { get; set; }
        public Loan Loan { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
    }
}
