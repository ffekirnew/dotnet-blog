using AspNetCore.Identity.MongoDbCore.Models;
using BlogApp.Application.Contracts.Identity.Models;
using MongoDbGenericRepository.Attributes;

namespace BlogApp.Identity.Models;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>, User
{
  public string FirstName { get; set; } = "";
  public string LastName { get; set; } = "";
}
