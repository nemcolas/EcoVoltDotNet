using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsTipoConsumidorRepository : IGsTipoConsumidorRepository
{
    private readonly AppDbContext _context;

    public GsTipoConsumidorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsTipoConsumidor>> GetAllAsync()
    {
        return await _context.GsTipoConsumidor.ToListAsync();
    }

    public async Task<GsTipoConsumidor> GetByIdAsync(int id)
    {
        return await _context.GsTipoConsumidor.FindAsync(id);
    }

    public async Task AddAsync(GsTipoConsumidor tipoConsumidor)
    {
        await _context.GsTipoConsumidor.AddAsync(tipoConsumidor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsTipoConsumidor tipoConsumidor)
    {
        _context.GsTipoConsumidor.Update(tipoConsumidor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoConsumidor = await _context.GsTipoConsumidor.FindAsync(id);
        if (tipoConsumidor != null)
        {
            _context.GsTipoConsumidor.Remove(tipoConsumidor);
            await _context.SaveChangesAsync();
        }
    }
}