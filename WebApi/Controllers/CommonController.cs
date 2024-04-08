using BlogApp.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommonController : ControllerBase
{
  private readonly IMediator _mediator;

  public CommonController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet("all")]
  public IActionResult All()
  {
    var response = CommonResponse<bool>.Success(true);
    return Ok(response);
  }

  [Authorize]
  [HttpGet("authorized")]
  public IActionResult Authorized()
  {
    Console.WriteLine(User);
    var response = CommonResponse<bool>.Success(true);
    return Ok(response);
  }
}
