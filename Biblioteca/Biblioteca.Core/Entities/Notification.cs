using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class Notification
    {
        //[Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(100)]
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
