using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsConsumidorRepository
{
    Task<IEnumerable<GsConsumidor>> GetAllAsync();
    Task<GsConsumidor> GetByIdAsync(int id);
    Task AddAsync(GsConsumidor entity);
    Task UpdateAsync(GsConsumidor entity);
    Task DeleteAsync(int id);
}