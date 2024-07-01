namespace DT.Model.Data.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool Deleted { get; set; }
    }
}
