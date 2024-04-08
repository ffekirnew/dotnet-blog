namespace BlogApp.Identity.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogApp.Application.Common.Exceptions;
using BlogApp.Application.Contracts.Identity.ConfigurationModels;
using BlogApp.Application.Contracts.Identity.Models;
using BlogApp.Application.Contracts.Identity.Services;
using BlogApp.Identity.Models;
using BlogApp.Identity.Services.DateTimeService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;
  private readonly RoleManager<ApplicationRole> _roleManager;
  private readonly JwtSettings _jwtSettings;
  private readonly IDateTimeProvider _dateTimeProvider;

  public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
      IOptions<JwtSettings> jwtSettings, RoleManager<ApplicationRole> roleManager, IDateTimeProvider dateTimeProvider)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _jwtSettings = jwtSettings.Value;
    _roleManager = roleManager;
    _dateTimeProvider = dateTimeProvider;
  }

  public async Task<LoginUserResponse> LoginUser(LoginUserRequest request)
  {
    var user = await _userManager.FindByNameAsync(request.UserName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user), request.UserName);
    }

    var isCorrect = await _signInManager.PasswordSignInAsync(
        userName: user.UserName ?? "",
        password: request.Password,
        isPersistent: true,
        lockoutOnFailure: false);

    if (!isCorrect.Succeeded)
    {
      throw new BadRequestException($"Invalid credentials for user: {request.UserName}");
    }


    var Token = GenerateToken(user);

    return new LoginUserResponse
    {
      Token = Token,
      User = user
    };
  }



  public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
  {
    var alreadyExist = await _userManager.FindByEmailAsync(request.Email);
    if (alreadyExist is not null)
    {
      throw new BadRequestException("Email already used.");
    }

    Console.WriteLine(request);

    var user = new ApplicationUser
    {
      Email = request.Email,
      UserName = request.UserName,
      EmailConfirmed = true
    };
    var creatingUser = await _userManager.CreateAsync(user, request.Password);
    Console.WriteLine(creatingUser);
    if (!creatingUser.Succeeded)
    {
      throw new BadRequestException($"Check Your Password \n");
    }

    return new RegisterUserResponse
    {
      User = user
    };
  }

  private string GenerateToken(ApplicationUser user)
  {
    // Generate signing signing credentials
    var signingCredentials = new SigningCredentials(
        // Since we will also be parsing the token for authorization later on, will use symmetic security key
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key ?? "")),
        SecurityAlgorithms.HmacSha256Signature
    );

    // Create claims
    var claims = new List<Claim>
      {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
          new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

    // Generate the token
    var securityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        audience: _jwtSettings.Audience,
        expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
        signingCredentials: signingCredentials,
        claims: claims
    );

    // Return the token
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
