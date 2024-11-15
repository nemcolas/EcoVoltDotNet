using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsTipoFonteRepository
{
    Task<IEnumerable<GsTipoFonte>> GetAllAsync();
    Task<GsTipoFonte> GetByIdAsync(int id);
    Task AddAsync(GsTipoFonte entity);
    Task UpdateAsync(GsTipoFonte entity);
    Task DeleteAsync(int id);
}