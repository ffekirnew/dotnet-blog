using BlogApp.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Identity.Seed;

public class SeedData
{
  private readonly RoleManager<ApplicationRole> _roleManager;
  private readonly UserManager<ApplicationUser> _userManager;


  public SeedData(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
  {
    _roleManager = roleManager;
    _userManager = userManager;
  }

  public async Task SeedUsersAndRoles()
  {
    // Seed roles
    var adminRole = new ApplicationRole { Name = "Admin" };
    var roleCreationResult = await _roleManager.CreateAsync(adminRole);
    if (!roleCreationResult.Succeeded)
    {
      throw new Exception("Failed to create admin role");
    }

    // Seed users
    var hasher = new PasswordHasher<ApplicationUser>();
    var adminUser = new ApplicationUser
    {
      UserName = "admin@rideshare.com",
      Email = "admin@rideshare.com",
      NormalizedUserName = "ADMIN@RIDESHARE.COM",
      EmailConfirmed = true,
      PasswordHash = hasher.HashPassword(null, "AdminPassword123") // Hash the password
    };

    var userCreationResult = await _userManager.CreateAsync(adminUser);
    if (!userCreationResult.Succeeded)
    {
      throw new Exception("Failed to create admin user");
    }

    var createdUser = await _userManager.FindByNameAsync(adminUser.UserName);
    await _userManager.AddToRolesAsync(createdUser, new List<string>() { adminRole.Name });
  }
}
