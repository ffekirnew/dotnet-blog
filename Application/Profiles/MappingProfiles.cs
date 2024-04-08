using AutoMapper;
using BlogApp.Application.Contracts.Identity.Models;
using BlogApp.Application.Features.Authentication.Dtos;

namespace BlogApp.Application.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    #region Identity Mappings
    CreateMap<RegisterUserResponse, LoggedInUserDto>();
    CreateMap<LoginUserResponse, LoggedInUserDto>();
    CreateMap<User, UserDto>();
    #endregion
  }
}
