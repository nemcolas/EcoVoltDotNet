using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsConsumoEnergiaRepository : IGsConsumoEnergiaRepository
{
    private readonly AppDbContext _context;

    public GsConsumoEnergiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsConsumoEnergia>> GetAllAsync()
    {
        return await _context.GsConsumoEnergia.ToListAsync();
    }

    public async Task<GsConsumoEnergia> GetByIdAsync(int id)
    {
        return await _context.GsConsumoEnergia.FindAsync(id);
    }

    public async Task AddAsync(GsConsumoEnergia consumoEnergia)
    {
        await _context.GsConsumoEnergia.AddAsync(consumoEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsConsumoEnergia consumoEnergia)
    {
        _context.GsConsumoEnergia.Update(consumoEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consumoEnergia = await _context.GsConsumoEnergia.FindAsync(id);
        if (consumoEnergia != null)
        {
            _context.GsConsumoEnergia.Remove(consumoEnergia);
            await _context.SaveChangesAsync();
        }
    }
}