using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
    public interface IHouseService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(HouseCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(HouseUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
