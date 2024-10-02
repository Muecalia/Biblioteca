using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Core.Entities
{
    public class BaseEntity
    {
        protected BaseEntity() 
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }

        //[Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
