using Biblioteca.Core.Entities;

namespace Biblioteca.Infrastructure.Interfaces
{
    public interface INotificationRepository
    {
        Task Create(Notification notification, CancellationToken cancellationToken);
        Task<List<Notification>> FindAll(CancellationToken cancellationToken);
        Task<Notification> FindDetail(int Id, CancellationToken cancellationToken);
    }
}
