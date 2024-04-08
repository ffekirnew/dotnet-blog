namespace BlogApp.Application.Contracts.Identity.Services;

using BlogApp.Application.Contracts.Identity.Models;

public interface IAuthService
{
  Task<LoginUserResponse> LoginUser(LoginUserRequest request);
  Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
}
