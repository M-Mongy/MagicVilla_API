using System.Linq.Expressions;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepostiory;

namespace MagicVilla_VillaAPI.Repository.IRepository.IRepository
{
    public interface IVillaReository :IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa Entity);
    }
}
