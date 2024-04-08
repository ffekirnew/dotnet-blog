using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;
using BlogApp.Application.Features.Authentication.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IMediator _mediator;

  public AuthController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
  {
    CommonResponse<LoggedInUserDto> response = await _mediator.Send(
        new RegisterUserCommand { RegisterUserDto = registerUserDto }
    );

    return Ok(response);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
  {
    CommonResponse<LoggedInUserDto> response = await _mediator.Send(
        new LoginUserCommand { LoginUserDto = loginUserDto }
    );

    return Ok(response);
  }
}
