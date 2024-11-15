using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsCidadeRepository
{
    Task<IEnumerable<GsCidade>> GetAllAsync();
    Task<GsCidade> GetByIdAsync(int id);
    Task AddAsync(GsCidade entity);
    Task UpdateAsync(GsCidade entity);
    Task DeleteAsync(int id);
}