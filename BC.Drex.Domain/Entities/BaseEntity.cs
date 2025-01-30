namespace BC.Drex.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Changed { get; set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; set; }
    }
}
