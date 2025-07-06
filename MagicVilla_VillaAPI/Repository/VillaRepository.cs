using System.Linq.Expressions;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository :Repository<Villa>, IVillaReository
    {
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
 
        public async Task<Villa> UpdateAsync(Villa Entity)
        {
            Entity.UpdateDate = DateTime.Now;
            _db.villas.Update(Entity);
            await _db.SaveChangesAsync();
            return Entity;
        }
    }
}
