using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsLocalizacaoRepository : IGsLocalizacaoRepository
{
    private readonly AppDbContext _context;

    public GsLocalizacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsLocalizacao>> GetAllAsync()
    {
        return await _context.GsLocalizacao.ToListAsync();
    }

    public async Task<GsLocalizacao> GetByIdAsync(int id)
    {
        return await _context.GsLocalizacao.FindAsync(id);
    }

    public async Task AddAsync(GsLocalizacao localizacao)
    {
        await _context.GsLocalizacao.AddAsync(localizacao);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsLocalizacao localizacao)
    {
        _context.GsLocalizacao.Update(localizacao);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var localizacao = await _context.GsLocalizacao.FindAsync(id);
        if (localizacao != null)
        {
            _context.GsLocalizacao.Remove(localizacao);
            await _context.SaveChangesAsync();
        }
    }
}