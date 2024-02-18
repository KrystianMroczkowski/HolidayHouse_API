using HolidayHouse_HouseAPI.Models;

namespace HolidayHouse_HouseAPI.Repository.IRepository
{
    public interface IHouseNumberRepository : IRepository<HouseNumber>
    {
        Task<HouseNumber> UpdateAsync(HouseNumber entity);
    }
}
