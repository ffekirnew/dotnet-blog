namespace BlogApp.Application.Features.Authentication.Dtos;

public class LoggedInUserDto
{
  public UserDto UserDto { get; set; } = null!;
  public string Token { get; set; } = null!;
}
