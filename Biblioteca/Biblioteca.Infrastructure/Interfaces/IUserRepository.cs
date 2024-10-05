using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        //Task<bool> Create(User user, string Password, string Profile, CancellationToken cancellationToken);
        Task<User> Create(User user, string Password, string Profile, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task<bool> ChangePassword(User user, string OldPassword, string NewPassword, CancellationToken cancellationToken);
        Task Delete(User user, CancellationToken cancellationToken);
        Task<List<User>> FindAll(CancellationToken cancellationToken);
        Task<User> Find(string Id, CancellationToken cancellationToken);
        Task<User> FindDetail(string Id, CancellationToken cancellationToken);
        Task<bool> IsExists(string Email, CancellationToken cancellationToken);
    }
}
