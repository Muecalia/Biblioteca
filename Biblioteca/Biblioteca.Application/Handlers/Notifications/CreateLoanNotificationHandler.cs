using Biblioteca.Application.Commands.Request.Notification;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Interfaces;
using MediatR;

namespace Biblioteca.Application.Handlers.Notifications
{
    public class CreateLoanNotificationHandler : INotificationHandler<CreateLoanNotificationRequest>
    {
        private readonly INotificationRepository _iNotificationRepository;

        public CreateLoanNotificationHandler(INotificationRepository iNotificationRepository)
        {
            _iNotificationRepository = iNotificationRepository;
        }

        public async Task Handle(CreateLoanNotificationRequest notification, CancellationToken cancellationToken)
        {
            try
            {
                var newNotification = new Notification
                {
                    CreatedAt = DateTime.Now,
                    Message = notification.Message
                };
                Console.WriteLine($"{notification.Message}. Data de devolução: {newNotification.CreatedAt.ToShortDateString()}");
                await _iNotificationRepository.Create(newNotification, cancellationToken);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"Erro ao registar a notificação da devolução dos livos. Mensagem: {ex.Message}");
                throw;
            }
        }
    }
}
