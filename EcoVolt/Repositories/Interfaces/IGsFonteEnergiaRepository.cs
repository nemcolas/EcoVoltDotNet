using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsFonteEnergiaRepository
{
    Task<IEnumerable<GsFonteEnergia>> GetAllAsync();
    Task<GsFonteEnergia> GetByIdAsync(int id);
    Task AddAsync(GsFonteEnergia entity);
    Task UpdateAsync(GsFonteEnergia entity);
    Task DeleteAsync(int id);
}