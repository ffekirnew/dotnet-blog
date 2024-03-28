namespace BlogApp.Application.Features.Authentication.Dtos;

public interface IUserDto
{
  public string Username { get; set; }
  public string Password { get; set; }
}
