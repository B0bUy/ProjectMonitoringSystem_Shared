namespace PMSv1_Shared.Entities.Contracts
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; } = null;
        public DateTime? UpdatedAt { get; set; } = null;
        public string? DeletedBy { get; set; } = null;
        public DateTime? DeletedAt { get; set; } = null;
    }
}
