using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsPaisRepository : IGsPaisRepository
{
    private readonly AppDbContext _context;

    public GsPaisRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsPais>> GetAllAsync()
    {
        return await _context.GsPais.ToListAsync();
    }

    public async Task<GsPais> GetByIdAsync(int id)
    {
        return await _context.GsPais.FindAsync(id);
    }

    public async Task AddAsync(GsPais entity)
    {
        await _context.GsPais.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsPais entity)
    {
        _context.GsPais.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.GsPais.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}