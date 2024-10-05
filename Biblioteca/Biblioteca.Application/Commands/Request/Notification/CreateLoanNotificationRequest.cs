using MediatR;

namespace Biblioteca.Application.Commands.Request.Notification
{
    public class CreateLoanNotificationRequest : INotification
    {
        public string Message { get; set; } = string.Empty;
        //public DateTime ReturnDate { get; set; } = DateTime.Now;
    }
}
