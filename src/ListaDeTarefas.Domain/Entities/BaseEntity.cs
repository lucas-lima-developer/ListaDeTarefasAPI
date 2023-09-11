namespace ListaDeTarefas.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTime.Now;
        public DateTimeOffset? DateUpdated { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
