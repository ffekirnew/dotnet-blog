namespace BlogApp.Application.Features.Authentication.Dtos;

public class LoginUserDto : IUserDto
{
  public string Username { get; set; } = null!;
  public string Password { get; set; } = null!;
}
