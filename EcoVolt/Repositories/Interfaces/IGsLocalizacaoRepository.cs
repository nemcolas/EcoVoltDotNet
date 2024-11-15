using EcoVolt.Models;

namespace EcoVolt.Repositories.Interfaces;

public interface IGsLocalizacaoRepository
{
    Task<IEnumerable<GsLocalizacao>> GetAllAsync();
    Task<GsLocalizacao> GetByIdAsync(int id);
    Task AddAsync(GsLocalizacao entity);
    Task UpdateAsync(GsLocalizacao entity);
    Task DeleteAsync(int id);
}