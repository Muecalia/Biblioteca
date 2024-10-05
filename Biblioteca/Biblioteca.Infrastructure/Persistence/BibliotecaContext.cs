using Biblioteca.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence
{
    //public class BibliotecaContext : DbContext
    public class BibliotecaContext : IdentityDbContext<User>
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanBooks> LoanBooks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        //public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>(e =>
            {
                e.HasKey(a => a.Id);

                e.HasIndex(a => a.Name);

                e.HasMany(a => a.Books)
                    .WithOne(a => a.Author)
                    .HasForeignKey(a => a.IdAuthor)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<AuthorBooks>(e => 
            {
                e.HasKey(ab => ab.Id);

                e.HasIndex(a => a.IdBook);
                e.HasIndex(a => a.IdAuthor);

                e.HasOne(ab => ab.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(a => a.IdAuthor)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(ab => ab.Book)
                    .WithMany(b => b.Authors)
                    .HasForeignKey(b => b.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);

                e.HasIndex(b => b.Title);

                e.HasMany(b => b.Authors)
                    .WithOne(b => b.Book)
                    .HasForeignKey(b => b.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Loan>(e =>
            {
                e.HasKey(l => l.Id);

                //e.HasIndex(l => l.IdEmployee);
                //e.HasIndex(l => l.IdCustomer);

                //e.HasOne(l => l.Employee)
                //    .WithMany(l => l.Loans)
                //    .HasForeignKey(l => l.IdEmployee)
                //    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(l => l.Customer)
                    .WithMany(l => l.Loans)
                    .HasForeignKey(l => l.IdCustomer)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<LoanBooks>(e => {
                e.HasKey(lb => lb.Id);

                e.HasIndex(lb => lb.IdLoan);
                e.HasIndex(lb => lb.IdBook);

                e.HasOne(lb => lb.Loan)
                    .WithMany(lb => lb.Books)
                    .HasForeignKey(lb => lb.IdLoan)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(lb => lb.Book)
                    .WithMany(lb => lb.Loans)
                    .HasForeignKey(lb =>lb.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            builder.Entity<Notification>(e =>
            {
                e.HasKey(u => u.Id);
            });

            builder.Entity<Stock>(e => 
            {
                e.HasKey(s => s.Id);

                //e.HasOne(s => s.Book)
                //    .WithOne(b => b.)
            });

            //builder.Entity<User>(e =>
            //{
            //    //e.HasKey(u => u.Id);

            //    e.HasIndex(u => u.Name);

            //    //e.HasMany(u => u.Loans)
            //    //    .WithOne(u => u.Customer)
            //    //    .HasForeignKey(c => c.IdCustomer)
            //    //    .OnDelete(DeleteBehavior.Restrict);

            //    //e.HasMany(u => u.Loans)
            //    //    .WithOne(u => u.Employee)
            //    //    .HasForeignKey(c => c.IdEmployee)
            //    //    .OnDelete(DeleteBehavior.Restrict);
            //});

            base.OnModelCreating(builder);
        }
    }
}
