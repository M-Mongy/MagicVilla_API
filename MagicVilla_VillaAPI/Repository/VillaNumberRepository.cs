using System.Linq.Expressions;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNumberRepository :Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
 
        public async Task<VillaNumber> UpdateAsync(VillaNumber Entity)
        {
            Entity.UpdatedDate = DateTime.Now;
            _db.villaNumbers.Update(Entity);
            await _db.SaveChangesAsync();
            return Entity;
        }
    }
}
