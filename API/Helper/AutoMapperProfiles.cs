using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SteamAccount, SteamAccountDto>();
            CreateMap<SteamAccountDto, SteamAccount>();
            CreateMap<List<SteamAccountDto>, SteamAccount>();
            CreateMap<SteamAccount, List<SteamAccountDto>>();
        }
    }
}