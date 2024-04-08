namespace BlogApp.Application.Contracts.Identity.Models;

public class LoginUserResponse
{
  public string? Token { get; set; }
  public User? User { get; set; }
}
