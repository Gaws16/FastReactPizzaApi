using FastReactPizzaApi.Models.Enums;

namespace FastReactPizzaApi.Dtos;

public class ApiResponse<T>
{
    public ResponseStatus Status { get; set; } 
    public T Data { get; set; } = default!;
}