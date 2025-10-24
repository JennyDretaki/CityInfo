using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.MappingProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDto>()
                .ForMember(
                    dest => dest.NumberOfPointsOfInterest,
                    opt => opt.MapFrom(src => src.PointsOfInterest.Count)
                );
            CreateMap<PointOfInterest, PointOfInterestDto>();
        
            CreateMap<Category, CategoryDto>();
        }
    }
}

