using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsEstadoRepository : IGsEstadoRepository
{
    private readonly AppDbContext _context;

    public GsEstadoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsEstado>> GetAllAsync()
    {
        return await _context.GsEstado.ToListAsync();
    }

    public async Task<GsEstado> GetByIdAsync(int id)
    {
        return await _context.GsEstado.FindAsync(id);
    }

    public async Task AddAsync(GsEstado entity)
    {
        await _context.GsEstado.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsEstado entity)
    {
        _context.GsEstado.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.GsEstado.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}