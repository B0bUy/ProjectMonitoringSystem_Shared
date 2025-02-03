using PMSv1_Shared.Entities.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PMSv1_Shared.Helpers
{
    public class ResponseObjectService
    {
        public ApiResponse<T> GetData<T>(byte[] jsonData)
        {
            ApiResponseConverter<T> converter = new ApiResponseConverter<T>();
            ApiResponse<T> getResponse = new ApiResponse<T>();
            var content = new Utf8JsonReader(jsonData);
            getResponse = converter.Read(ref content, typeof(ApiResponse<T>), new JsonSerializerOptions());
            return getResponse;
        }
    }
    public class ApiResponseConverter<T> : JsonConverter<ApiResponse<T>>
    {
        public override ApiResponse<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;

            return new ApiResponse<T>
            {
                StatusCode = jsonObject.GetProperty("statusCode").GetInt32(),
                Message = jsonObject.GetProperty("message").GetString() ?? string.Empty,
                IsSuccess = jsonObject.GetProperty("isSuccess").GetBoolean(),
                Result = jsonObject.TryGetProperty("result", out var resultProperty) && resultProperty.ValueKind != JsonValueKind.Null
                    ? JsonSerializer.Deserialize<T>(resultProperty.GetRawText(), options)!
                    : default!
            };
        }

        public override void Write(Utf8JsonWriter writer, ApiResponse<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteNumber("statusCode", value.StatusCode);
            writer.WriteString("message", value.Message);
            writer.WriteBoolean("isSuccess", value.IsSuccess);
            writer.WritePropertyName("result");
            JsonSerializer.Serialize(writer, value.Result, options);
            writer.WriteEndObject();
        }
    }
}
