using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Biblioteca.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly BibliotecaContext _context;

        public UserRepository(BibliotecaContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> ChangePassword(User user, string OldPassword, string NewPassword, CancellationToken cancellationToken)
        {
            var result = await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
            return result.Succeeded;
        }

        //public async Task<bool> Create(User user, string Password, string Profile, CancellationToken cancellationToken)
        public async Task<User> Create(User user, string Password, string Profile, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userManager.CreateAsync(user, Password);

                //if (!result.Succeeded)
                //    return false;

                //var resultRole = await _userManager.AddToRoleAsync(user, Profile);

                // Retorna os erros
                var sb = new StringBuilder();

                result.Errors.ToList().ForEach(x => sb.Append(x.Description));
                Console.WriteLine($"Erro result errors 1: {sb}");
                System.Diagnostics.Debug.Print($"Erro result errors 2: {sb}");

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a conta. Mensagem: {ex.Message}");
                System.Diagnostics.Debug.Print($"Erro ao criar a conta. Mensagem: {ex.Message}");
                throw;
            }
        }

        public async Task Delete(User user, CancellationToken cancellationToken)
        {
            user.DeletedAt = DateTime.Now;
            user.IsDeleted = true;
            await _userManager.DeleteAsync(user);
        }

        public async Task<User?> Find(string Id, CancellationToken cancellationToken)
        {
            return await _userManager.Users.IgnoreAutoIncludes().FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == Id, cancellationToken);
        }

        public async Task<List<User>> FindAll(CancellationToken cancellationToken)
        {
            return await _userManager.Users
                .IgnoreAutoIncludes()
                .Where(u => !u.IsDeleted)
                .ToListAsync(cancellationToken);

            /*var users = await _context.Users
                .IgnoreAutoIncludes()
                .Where(u => !u.IsDeleted)
                .ToListAsync(cancellationToken);*/

            //System.Diagnostics.Debug.WriteLine($"Count: {users.Count}");

            //return users;
        }

        public async Task<User?> FindDetail(string Id, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.IgnoreAutoIncludes().FirstOrDefaultAsync(u => u.Id == Id, cancellationToken);

            if (user is null) return null;

            user.Loans = await _context.Loans.Where(l => string.Equals(l.IdCustomer, user.Id)).ToListAsync(cancellationToken);

            return user;
        }

        public async Task<bool> IsExists(string Id, CancellationToken cancellationToken)
        {
            return await _userManager.Users.AnyAsync(u => !u.IsDeleted && string.Equals(u.Id, Id), cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            user.UpdatedAt = DateTime.Now;
            await _userManager.UpdateAsync(user);
        }

    }
}
