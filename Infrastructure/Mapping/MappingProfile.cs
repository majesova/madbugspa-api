using AutoMapper;
using MadBugAPI.Controllers.Dtos;
using MadBugAPI.Data.Entities;

namespace MadBugAPI.Infrastructure.Mapping
{
    public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<AppUser, RegisterUserResponseDto>();
        CreateMap<BugRegisterDto, Bug>();
        CreateMap<Bug, BugResponseDto>();
        CreateMap<BugUpdateDto, Bug>();
        }
    }
}