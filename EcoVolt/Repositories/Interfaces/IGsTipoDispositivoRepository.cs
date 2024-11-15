using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsTipoDispositivoRepository
{
    Task<IEnumerable<GsTipoDispositivo>> GetAllAsync();
    Task<GsTipoDispositivo> GetByIdAsync(int id);
    Task AddAsync(GsTipoDispositivo entity);
    Task UpdateAsync(GsTipoDispositivo entity);
    Task DeleteAsync(int id);
}