namespace PMSv1_Shared.Entities.Contracts
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public T Result { get; set; } = default!;
    }
    public class ApiResponse
    {
        public int StatusCode { get; set; } = 0;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
    }
}
