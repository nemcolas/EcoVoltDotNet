using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsTipoConsumidorRepository
{
    Task<IEnumerable<GsTipoConsumidor>> GetAllAsync();
    Task<GsTipoConsumidor> GetByIdAsync(int id);
    Task AddAsync(GsTipoConsumidor entity);
    Task UpdateAsync(GsTipoConsumidor entity);
    Task DeleteAsync(int id);
}