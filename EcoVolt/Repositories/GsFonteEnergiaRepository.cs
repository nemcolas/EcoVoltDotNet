using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsFonteEnergiaRepository : IGsFonteEnergiaRepository
{
    private readonly AppDbContext _context;

    public GsFonteEnergiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsFonteEnergia>> GetAllAsync()
    {
        return await _context.GsFonteEnergia.ToListAsync();
    }

    public async Task<GsFonteEnergia> GetByIdAsync(int id)
    {
        return await _context.GsFonteEnergia.FindAsync(id);
    }

    public async Task AddAsync(GsFonteEnergia fonteEnergia)
    {
        await _context.GsFonteEnergia.AddAsync(fonteEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsFonteEnergia fonteEnergia)
    {
        _context.GsFonteEnergia.Update(fonteEnergia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var fonteEnergia = await _context.GsFonteEnergia.FindAsync(id);
        if (fonteEnergia != null)
        {
            _context.GsFonteEnergia.Remove(fonteEnergia);
            await _context.SaveChangesAsync();
        }
    }
}