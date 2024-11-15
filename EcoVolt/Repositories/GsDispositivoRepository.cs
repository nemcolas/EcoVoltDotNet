using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsDispositivoRepository : IGsDispositivoRepository
{
    private readonly AppDbContext _context;

    public GsDispositivoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsDispositivo>> GetAllAsync()
    {
        return await _context.GsDispositivo.ToListAsync();
    }

    public async Task<GsDispositivo> GetByIdAsync(int id)
    {
        return await _context.GsDispositivo.FindAsync(id);
    }

    public async Task AddAsync(GsDispositivo dispositivo)
    {
        await _context.GsDispositivo.AddAsync(dispositivo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsDispositivo dispositivo)
    {
        _context.GsDispositivo.Update(dispositivo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var dispositivo = await _context.GsDispositivo.FindAsync(id);
        if (dispositivo != null)
        {
            _context.GsDispositivo.Remove(dispositivo);
            await _context.SaveChangesAsync();
        }
    }
}