using AutoMapper;
using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Models.Dto;

namespace HolidayHouse_HouseAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<House, HouseDTO>().ReverseMap();
            CreateMap<House, HouseUpdateDTO>().ReverseMap();
            CreateMap<House, HouseCreateDTO>().ReverseMap();

            CreateMap<HouseNumber, HouseNumberDTO>().ReverseMap();
            CreateMap<HouseNumber, HouseNumberCreateDTO>().ReverseMap();
            CreateMap<HouseNumber, HouseNumberUpdateDTO>().ReverseMap();
        }
    }
}
