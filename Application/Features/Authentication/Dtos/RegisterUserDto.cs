namespace BlogApp.Application.Features.Authentication.Dtos;

public class RegisterUserDto : IUserDto
{
  public string FirstName { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string Bio { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string UserName { get; set; } = null!;
  public string Password { get; set; } = null!;
  public string Phone { get; set; } = null!;
}
