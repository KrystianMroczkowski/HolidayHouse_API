using HolidayHouse_Web.Models.Dto;

namespace HolidayHouse_Web.Services.IServices
{
    public interface IHouseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(HouseCreateDTO dto);
        Task<T> UpdateAsync<T>(HouseUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
