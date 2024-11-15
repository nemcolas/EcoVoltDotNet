using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsBairroRepository : IGsBairroRepository
{
    private readonly AppDbContext _context;

    public GsBairroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsBairro>> GetAllAsync()
    {
        return await _context.GsBairro.ToListAsync();
    }

    public async Task<GsBairro> GetByIdAsync(int id)
    {
        return await _context.GsBairro.FindAsync(id);
    }

    public async Task AddAsync(GsBairro bairro)
    {
        await _context.GsBairro.AddAsync(bairro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsBairro bairro)
    {
        _context.GsBairro.Update(bairro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var bairro = await _context.GsBairro.FindAsync(id);
        if (bairro != null)
        {
            _context.GsBairro.Remove(bairro);
            await _context.SaveChangesAsync();
        }
    }
}