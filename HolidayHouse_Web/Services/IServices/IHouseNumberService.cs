using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
    public interface IHouseNumberService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(HouseNumberCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(HouseNumberUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
