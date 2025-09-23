using AutoMapper;
using DataAccess.Models;
using GhiseuBon.Dtos;

namespace GhiseuBon.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BonDto, BonModel>().ReverseMap();
        CreateMap<GhiseuDto, GhiseuModel>().ReverseMap();
    }
}
