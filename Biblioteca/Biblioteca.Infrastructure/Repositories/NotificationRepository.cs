using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly BibliotecaContext _context;

        public NotificationRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task Create(Notification notification, CancellationToken cancellationToken)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Notification>> FindAll(CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .ToListAsync(cancellationToken);
        }

        public async Task<Notification?> FindDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .FirstOrDefaultAsync(n => n.Id == Id, cancellationToken);
        }
    }
}
