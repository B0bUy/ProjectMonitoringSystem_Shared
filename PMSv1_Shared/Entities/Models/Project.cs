using Microsoft.EntityFrameworkCore;
using PMSv1_Shared.Entities.Contracts;
using PMSv1_Shared.Entities.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSv1_Shared.Entities.Models
{
    [Index(nameof(Name), nameof(Description))]
    public class Package : BaseEntity
    {
        [Key]
        public Guid PackageId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string Color { get; set; } = string.Empty;
    }

    [Index(nameof(Name), nameof(Description), nameof(Deadline))]
    public class Project : BaseEntity
    {
        [Key]
        public Guid ProjectId { get; set; } = Guid.NewGuid();
        public Guid PackageId { get; set; } = Guid.Empty;
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public DateTime? TimeLineStart { get; set; } = null;
        public DateTime? TimeLineEnd { get; set; } = null;
        public DateTime? Deadline { get; set; } = null;
    }

    [Index(nameof(Name), nameof(Description))]
    public class Department : BaseEntity
    {
        [Key]
        public Guid DepartmentId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Logo { get; set; } = null;
        public string Color { get; set; } = string.Empty;
    }

    public class ProjectStatus : BaseEntity
    {
        [Key]
        public Guid ProjectStatusId { get; set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; } = Guid.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid? StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public Guid ClientId { get; set; } = Guid.Empty;
        [ForeignKey("ClientId")]
        public User Client { get; set; }
    }

    [Index(nameof(Name))]
    public class Status : BaseEntity
    {
        [Key]
        public Guid StatusId { get; set; } = Guid.NewGuid();
        public int StatusType { get; set; } = 0;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class TaskStatus : BaseEntity
    {
        [Key]
        public Guid TaskStatusId { get; set; } = Guid.NewGuid();
        public Guid TaskId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Tasks Task { get; set; }
        public Guid StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }

    [Index(nameof(Name), nameof(Description), nameof(Deadline))]
    public class Tasks : BaseEntity
    {
        [Key]
        public Guid TaskId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Guid? ParentTaskId { get; set; } = null;
        [ForeignKey("ParentTaskId")]
        public Tasks ParentTask { get; set; }
        public Guid? ProjectId { get; set; } = null;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid? DepartmentId { get; set; } = null;
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public DateTime? TimeLineStart { get; set; } = null;
        public DateTime? TimeLineEnd { get; set; } = null;
        public DateTime? Deadline { get; set; } = null; 

    }

    public class UserTask : BaseEntity
    {
        [Key]
        public Guid UserTaskId { get; set; } = Guid.NewGuid();
        public Guid TaskId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Tasks Task { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    public class ItemHistory : BaseEntity
    {
        [Key]
        public Guid ItemHistoryId { get; set; } = Guid.NewGuid();
        public Guid? ProjectId { get; set; } = Guid.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid? TaskId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Tasks Task { get; set; }
        public Guid? DepartmentId { get; set; } = Guid.Empty;
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid? StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int Movement { get; set; } = 0;
        public DateTime MovedAt { get; set; } = DateTime.Now;
        public Guid MovedBy { get; set; } = Guid.Empty;
    }

    public class Client : BaseEntity
    {
        [Key]
        public Guid ClientId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Logo { get; set; } = null;
        public string? Color { get; set; } = string.Empty;
    }

    public class ClientInclusion : BaseEntity
    {
        [Key]
        public Guid ClientInclusionId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; } = Guid.Empty;
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public Guid? ProjectId { get; set; } = Guid.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid? PackageId { get; set; } = Guid.Empty;
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
    }
}
