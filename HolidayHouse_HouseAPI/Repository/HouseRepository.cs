using HolidayHouse_HouseAPI.Data;
using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace HolidayHouse_HouseAPI.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        private readonly ApplicationDbContext _db;

        public HouseRepository(ApplicationDbContext db) : base(db)
        {
           _db = db;
        }
        public async Task<House> UpdateAsync(House entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Update(entity);
            await _db.SaveChangesAsync();  
            return entity;
        }
    }
}
