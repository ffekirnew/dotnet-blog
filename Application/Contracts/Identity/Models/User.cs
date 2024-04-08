namespace BlogApp.Application.Contracts.Identity.Models;

public interface User
{
  public string? Email { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}
