using System.Collections.Generic;
using System.Threading.Tasks;
using EcoVolt.Models;

namespace EcoVolt.Services
{
    public interface IGsPaisService
    {
        Task<IEnumerable<GsPais>> GetAllAsync();
        Task<GsPais> GetByIdAsync(int id);
        Task AddAsync(GsPais pais);
        Task UpdateAsync(GsPais pais);
        Task DeleteAsync(int id);
    }
}