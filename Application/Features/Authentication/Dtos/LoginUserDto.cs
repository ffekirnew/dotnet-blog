namespace BlogApp.Application.Features.Authentication.Dtos;

public class LoginUserDto : IUserDto
{
  public string UserName { get; set; } = null!;
  public string Password { get; set; } = null!;
}
