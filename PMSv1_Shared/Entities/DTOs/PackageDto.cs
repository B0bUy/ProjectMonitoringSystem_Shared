using PMSv1_Shared.Entities.Contracts;
using System.ComponentModel.DataAnnotations;

namespace PMSv1_Shared.Entities.DTOs
{
    public class PackageDto : BaseEntity
    {
        public Guid PackageId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Color { get; set; } = string.Empty;
    }

    public class ProjectDto : BaseEntity
    {
        public Guid ProjectId { get; set; } = Guid.NewGuid();
        public Guid PackageId { get; set; } = Guid.Empty;
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public DateTime? TimeLineStart { get; set; } = null;
        public DateTime? TimeLineEnd { get; set; } = null;
        public DateTime? Deadline { get; set; } = null;
    }

    public class DepartmentDto : BaseEntity
    {
        public Guid DepartmentId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Logo { get; set; } = null;
        public string? Color { get; set; } = string.Empty;
    }

    public class ClientDto : BaseEntity
    {
        public Guid ClientId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Logo { get; set; } = null;
        public string? Color { get; set; } = string.Empty;
    }

    public class ClientInclusionDto : BaseEntity
    {
        public Guid ClientInclusionId { get; set; } = Guid.NewGuid();
        public Guid ClientId { get; set; } = Guid.Empty;
        public string ClientName { get; set; } = string.Empty;
        public Guid? ProjectId { get; set; } = Guid.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public Guid? PackageId { get; set; } = Guid.Empty;
        public string PackageName { get; set; } = string.Empty;
    }
}
