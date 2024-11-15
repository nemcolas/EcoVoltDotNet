using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsDispositivoRepository
{
    Task<IEnumerable<GsDispositivo>> GetAllAsync();
    Task<GsDispositivo> GetByIdAsync(int id);
    Task AddAsync(GsDispositivo entity);
    Task UpdateAsync(GsDispositivo entity);
    Task DeleteAsync(int id);
}