using FastReactPizzaApi.Models.Enums;

namespace FastReactPizzaApi.Dtos;

public class ApiResponse<T>
{
    public string Status { get; set; } = String.Empty;
    public T Data { get; set; } = default!;
    
    public static ApiResponse<T> Success(T data) =>
    new ApiResponse<T> { Status = ResponseStatus.Success.ToString(), Data = data };

    public static ApiResponse<T> Fail(string errorr) =>
        new ApiResponse<T>
        {
            Status = ResponseStatus.Error.ToString(),
        };

}