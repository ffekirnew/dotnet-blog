namespace BlogApp.Application.Common.Responses;

public class CommonResponse<T>
{
  public bool IsSuccess { get; set; }

  public List<string>? Errors { get; set; }

  public T? Value { get; set; }

  public string? Message { get; set; }

  public static CommonResponse<T> Success(T value) =>
      new() { Value = value, IsSuccess = true };

  public static CommonResponse<T> Failure(string message) =>
      new() { Message = message, IsSuccess = false };

  public static CommonResponse<T> FailureWithError(string message, List<string> errors) =>
      new()
      {
        Message = message,
        Errors = errors,
        IsSuccess = false
      };
}
