using PMSv1_Shared.Entities.Contracts;

namespace PMSv1_Shared.Helpers
{
    public class ResponseObjectService
    {
        public async Task<T> GetData<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            var data = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<T>>(result);
            return data == null ? Activator.CreateInstance<T>() : data.Result;
        }
    }
}
