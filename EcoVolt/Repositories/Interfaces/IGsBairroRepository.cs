namespace EcoVolt.Repositories.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;
using EcoVolt.Models;

public interface IGsBairroRepository
{
    Task<IEnumerable<GsBairro>> GetAllAsync();
    Task<GsBairro> GetByIdAsync(int id);
    Task AddAsync(GsBairro entity);
    Task UpdateAsync(GsBairro entity);
    Task DeleteAsync(int id);
}
