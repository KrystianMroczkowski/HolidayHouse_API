using AutoMapper;
using HolidayHouse_Web.Models;
using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        { 
            CreateMap<HouseNumberDTO, HouseNumberCreateDTO>().ReverseMap();
            CreateMap<HouseNumberDTO, HouseNumberUpdateDTO>().ReverseMap();

            CreateMap<HouseDTO, HouseCreateDTO>().ReverseMap();
            CreateMap<HouseDTO, HouseUpdateDTO>().ReverseMap();
        }
    }
}
