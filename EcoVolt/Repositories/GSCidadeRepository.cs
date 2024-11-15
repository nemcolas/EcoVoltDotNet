using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsCidadeRepository : IGsCidadeRepository
{
    private readonly AppDbContext _context;

    public GsCidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsCidade>> GetAllAsync()
    {
        return await _context.GsCidade.ToListAsync();
    }

    public async Task<GsCidade> GetByIdAsync(int id)
    {
        return await _context.GsCidade.FindAsync(id);
    }

    public async Task AddAsync(GsCidade entity)
    {
        await _context.GsCidade.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsCidade entity)
    {
        _context.GsCidade.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _context.GsCidade.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}