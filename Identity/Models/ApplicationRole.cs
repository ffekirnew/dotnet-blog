using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace BlogApp.Identity.Models;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{ }

