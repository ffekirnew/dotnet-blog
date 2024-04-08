namespace BlogApp.Application.Contracts.Identity.Models;

public class LoginUserRequest
{
  public string UserName { get; set; } = "";
  public string Password { get; set; } = "";
}
