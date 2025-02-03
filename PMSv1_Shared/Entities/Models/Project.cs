using PMS_Serverv1.Entities.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_Serverv1.Entities.Models
{
    public class Package : BaseEntity
    {
        [Key]
        public Guid PackageId { get; set; } = Guid.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class Project : BaseEntity
    {
        [Key]
        public Guid ProjectId { get; set; } = Guid.Empty;
        public Guid PackageId { get; set; } = Guid.Empty;
        [ForeignKey("PackageId")]
        public Package Package { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class Department : BaseEntity
    {
        [Key]
        public Guid DepartmentId { get; set; } = Guid.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class ProjectStatus : BaseEntity
    {
        [Key]
        public Guid ProjectStatusId { get; set; } = Guid.Empty;
        public Guid ProjectId { get; set; } = Guid.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid DepartmentId { get; set; } = Guid.Empty;
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid? StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }

    public class Status : BaseEntity
    {
        [Key]
        public Guid StatusId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    public class Task : BaseEntity
    {
        [Key]
        public Guid TaskId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ProjectId { get; set; } = Guid.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public Guid StatusId { get; set; } = Guid.Empty;
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public Guid DepartmentId { get; set; } = Guid.Empty;
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
