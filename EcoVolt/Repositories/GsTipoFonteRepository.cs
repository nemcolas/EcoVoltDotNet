using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsTipoFonteRepository : IGsTipoFonteRepository
{
    private readonly AppDbContext _context;

    public GsTipoFonteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsTipoFonte>> GetAllAsync()
    {
        return await _context.GsTipoFonte.ToListAsync();
    }

    public async Task<GsTipoFonte> GetByIdAsync(int id)
    {
        return await _context.GsTipoFonte.FindAsync(id);
    }

    public async Task AddAsync(GsTipoFonte tipoFonte)
    {
        await _context.GsTipoFonte.AddAsync(tipoFonte);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsTipoFonte tipoFonte)
    {
        _context.GsTipoFonte.Update(tipoFonte);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoFonte = await _context.GsTipoFonte.FindAsync(id);
        if (tipoFonte != null)
        {
            _context.GsTipoFonte.Remove(tipoFonte);
            await _context.SaveChangesAsync();
        }
    }
}