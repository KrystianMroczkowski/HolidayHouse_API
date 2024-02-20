using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
    public interface IHouseNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(HouseNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(HouseNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
