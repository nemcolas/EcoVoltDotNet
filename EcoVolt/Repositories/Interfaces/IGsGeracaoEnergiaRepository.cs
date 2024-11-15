using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsGeracaoEnergiaRepository
{
    Task<IEnumerable<GsGeracaoEnergia>> GetAllAsync();
    Task<GsGeracaoEnergia> GetByIdAsync(int id);
    Task AddAsync(GsGeracaoEnergia entity);
    Task UpdateAsync(GsGeracaoEnergia entity);
    Task DeleteAsync(int id);
}