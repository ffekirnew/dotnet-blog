namespace BlogApp.Application.Features.Authentication.Requests.Commands;

using MediatR;
using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;


public class LoginUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
  public LoginUserDto RegisterUserDto { get; set; } = null!;
}
