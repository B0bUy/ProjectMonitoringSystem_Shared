using Microsoft.EntityFrameworkCore;
using PMS_Serverv1.Entities.Contracts;
using PMS_Serverv1.Entities.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PMS_Serverv1.Entities.Models
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
        public Department Department { get; set; }
        public Guid? StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }

    [Index(nameof(Name))]
    public class Status : BaseEntity
    {
        [Key]
        public Guid StatusId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class TaskStatus : BaseEntity
    {
        [Key]
        public Guid TaskStatusId { get; set; } = Guid.NewGuid();
        public Guid TaskId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
        public Guid StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }

    [Index(nameof(Name), nameof(Description), nameof(Deadline))]
    public class Task : BaseEntity
    {
        [Key]
        public Guid TaskId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public Guid? ParentTaskId { get; set; } = null;
        [ForeignKey("ParentTaskId")]
        public Task ParentTask { get; set; }
        public Guid? ProjectId { get; set; } = null;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid? DepartmentId { get; set; } = null;
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public DateTime? Deadline { get; set; } = null;
    }
     
    public class UserTask : BaseEntity
    {
        [Key]
        public Guid UserTaskId { get; set; } = Guid.NewGuid();
        public Guid TaskId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    public class TaskMovement : BaseEntity
    {
        [Key]
        public Guid TaskMovementId { get; set; } = Guid.NewGuid();
        public Guid TaskStatusId { get; set; } = Guid.Empty;
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
