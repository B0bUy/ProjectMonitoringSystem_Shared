namespace PMSv1_Shared.Entities.Filters.FilterModel
{
    public enum ProjectFilter
    {
        CreatedAt,
        Deadline,
        Status,
        Department,
        Package,
        Name
    }
    public enum PackageFilter
    {
        CreatedAt,
        Projects,
        Name,
    }
    public enum TaskFilter
    {
        CreatedAt,
        Deadline,
        Status,
        Department,
        Project,
        Package,
        Name
    }

    public class FilterRequest
    {
        public int FilterType { get; set; }
        public string FilterValue { get; set; } = string.Empty;
    }
}
