using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsConsumidorRepository : IGsConsumidorRepository
{
    private readonly AppDbContext _context;

    public GsConsumidorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsConsumidor>> GetAllAsync()
    {
        return await _context.GsConsumidor.ToListAsync();
    }

    public async Task<GsConsumidor> GetByIdAsync(int id)
    {
        return await _context.GsConsumidor.FindAsync(id);
    }

    public async Task AddAsync(GsConsumidor consumidor)
    {
        await _context.GsConsumidor.AddAsync(consumidor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsConsumidor consumidor)
    {
        _context.GsConsumidor.Update(consumidor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consumidor = await _context.GsConsumidor.FindAsync(id);
        if (consumidor != null)
        {
            _context.GsConsumidor.Remove(consumidor);
            await _context.SaveChangesAsync();
        }
    }
}