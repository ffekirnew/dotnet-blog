namespace BlogApp.Application.Features.Authentication.Dtos;

public interface IUserDto
{
  public string UserName { get; set; }
  public string Password { get; set; }
}
