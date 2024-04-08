namespace BlogApp.Application.Contracts.Identity.Models;

public class RegisterUserRequest
{
  public string UserName { get; set; } = "";
  public string FirstName { get; set; } = "";
  public string LastName { get; set; } = "";
  public string Email { get; set; } = "";
  public string Password { get; set; } = "";
}
