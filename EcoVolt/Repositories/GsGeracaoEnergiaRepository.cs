using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsGeracaoEnergiaRepository : IGsGeracaoEnergiaRepository
{
    private readonly AppDbContext _context;

    public GsGeracaoEnergiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsGeracaoEnergia>> GetAllAsync()
    {
        return await _context.GsGeracaoEnergia.ToListAsync();
    }

    public async Task<GsGeracaoEnergia> GetByIdAsync(int id)
    {
        return await _context.GsGeracaoEnergia.FindAsync(id);
    }

    public async Task AddAsync(GsGeracaoEnergia geracaoEnergia)
    {
        await _context.GsGeracaoEnergia.AddAsync(geracaoEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsGeracaoEnergia geracaoEnergia)
    {
        _context.GsGeracaoEnergia.Update(geracaoEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var geracaoEnergia = await _context.GsGeracaoEnergia.FindAsync(id);
        if (geracaoEnergia != null)
        {
            _context.GsGeracaoEnergia.Remove(geracaoEnergia);
            await _context.SaveChangesAsync();
        }
    }
}