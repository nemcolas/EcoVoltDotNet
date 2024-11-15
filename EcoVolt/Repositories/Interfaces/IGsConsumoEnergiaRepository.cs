using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsConsumoEnergiaRepository
{
    Task<IEnumerable<GsConsumoEnergia>> GetAllAsync();
    Task<GsConsumoEnergia> GetByIdAsync(int id);
    Task AddAsync(GsConsumoEnergia entity);
    Task UpdateAsync(GsConsumoEnergia entity);
    Task DeleteAsync(int id);
}