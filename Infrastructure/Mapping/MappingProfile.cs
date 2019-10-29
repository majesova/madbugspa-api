using AutoMapper;
using MadBugAPI.Controllers.Dtos;
using MadBugAPI.Entities;

namespace MadBugAPI.Infrastructure.Mapping
{
    public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<AppUser, RegisterUserResponseDto>();
        }
    }
}