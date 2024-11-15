using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsEstadoRepository
{
    Task<IEnumerable<GsEstado>> GetAllAsync();
    Task<GsEstado> GetByIdAsync(int id);
    Task AddAsync(GsEstado entity);
    Task UpdateAsync(GsEstado entity);
    Task DeleteAsync(int id);
}