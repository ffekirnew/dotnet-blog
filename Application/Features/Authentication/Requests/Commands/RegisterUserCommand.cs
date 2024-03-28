namespace BlogApp.Application.Features.Authentication.Requests.Commands;

using MediatR;
using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;


public class RegisterUserCommand : IRequest<CommonResponse<LoggedInUserDto>>
{
  public RegisterUserDto RegisterUserDto { get; set; } = null!;
}
