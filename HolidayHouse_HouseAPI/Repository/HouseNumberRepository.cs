using HolidayHouse_HouseAPI.Data;
using HolidayHouse_HouseAPI.Models;
using HolidayHouse_HouseAPI.Repository.IRepository;

namespace HolidayHouse_HouseAPI.Repository
{
    public class HouseNumberRepository : Repository<HouseNumber>, IHouseNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public HouseNumberRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public async Task<HouseNumber> UpdateAsync(HouseNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
