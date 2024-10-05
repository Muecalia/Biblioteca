namespace Biblioteca.Core.Entities
{
    public class Stock : BaseEntity
    {
        public int IdBook { get; set; }
        public Book Book { get; set; }
        public int QtdBooks { get; set; }
        public string IdUser { get; set; }
        public User User { get; set; }
    }
}
