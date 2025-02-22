using PMSv1_Shared.Entities.Contracts;

namespace PMSv1_Shared.Entities.DTOs
{
    public class TaskDto : BaseEntity
    {
        public Guid TaskId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Guid? ParentTaskId { get; set; } = null;
        public Guid? ProjectId { get; set; } = null;
        public Guid? DepartmentId { get; set; } = null;
        public DateTime? Deadline { get; set; } = null;
    }

    public class UserTaskDto : BaseEntity
    {
        public Guid UserTaskId { get; set; } = Guid.NewGuid();
        public Guid TaskId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;
    }
}
