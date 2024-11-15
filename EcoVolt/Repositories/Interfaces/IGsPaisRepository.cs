using EcoVolt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoVolt.Repositories.Interfaces
{
    public interface IGsPaisRepository
    {
        Task<IEnumerable<GsPais>> GetAllAsync();
        Task<GsPais> GetByIdAsync(int id);
        Task AddAsync(GsPais gsPais);
        Task UpdateAsync(GsPais gsPais);
        Task DeleteAsync(int id);
    }
}