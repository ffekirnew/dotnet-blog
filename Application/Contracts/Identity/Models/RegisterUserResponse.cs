namespace BlogApp.Application.Contracts.Identity.Models;

public class RegisterUserResponse
{
  public string? Token { get; set; }
  public User? User { get; set; }
}
