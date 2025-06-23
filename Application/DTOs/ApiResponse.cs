namespace App.Application.DTOs;

public class ApiResponse<T>
{
    public string Message { get; set; } = null!;
    public T Data { get; set; } = default!;
}