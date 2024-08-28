namespace MotoFleet.SharedKernel;

public record Result<T>
{
    public T Data { get; init; }
    public bool IsSuccess { get; init; }
    public string ErrorMessage { get; init; }
    
    public static Result<T> Success(T data) 
        => new() { Data = data, IsSuccess = true };
    
    public static Result<T> Failure(string errorMessage) 
        => new () { ErrorMessage = errorMessage, IsSuccess = false };
    
    public static implicit operator bool(Result<T> result) => result.IsSuccess;
    
    public static implicit operator T(Result<T> result) => result.Data;
    
    public static implicit operator Result<T>(T data) => Success(data);
    
    public static implicit operator Result<T>(string message) => Failure(message);
}
