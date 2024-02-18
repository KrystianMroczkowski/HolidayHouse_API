using HolidayHouse_HouseAPI.Models;
using System.Linq.Expressions;

namespace HolidayHouse_HouseAPI.Repository.IRepository
{
    public interface IHouseRepository : IRepository<House>
    { 
        Task<House> UpdateAsync(House entity); 
    }
}
