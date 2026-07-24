using AutoMapper;
using SignalChain.Models;
using SignalChain.Models.DTOs;

namespace SignalChain.Models;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Gear, GearDTO>();
        CreateMap<GearDTO, Gear>();
        CreateMap<GearType, GearTypeDTO>();
        CreateMap<GearTypeDTO, GearType>();
        CreateMap<Song, SongDTO>();
        CreateMap<SongDTO, Song>();
        CreateMap<Status, StatusDTO>();
        CreateMap<StatusDTO, Status>();
        CreateMap<Song, BasicSongDTO>();
        CreateMap<Gear, BasicGearDTO>();
        CreateMap<UserProfile, UserProfileDTO>();
        CreateMap<UserProfileDTO, UserProfile>();
    }
}