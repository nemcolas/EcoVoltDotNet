using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Repositories;

public class GsTipoDispositivoRepository : IGsTipoDispositivoRepository
{
    private readonly AppDbContext _context;

    public GsTipoDispositivoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GsTipoDispositivo>> GetAllAsync()
    {
        return await _context.GsTipoDispositivo.ToListAsync();
    }

    public async Task<GsTipoDispositivo> GetByIdAsync(int id)
    {
        return await _context.GsTipoDispositivo.FindAsync(id);
    }

    public async Task AddAsync(GsTipoDispositivo tipoDispositivo)
    {
        await _context.GsTipoDispositivo.AddAsync(tipoDispositivo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GsTipoDispositivo tipoDispositivo)
    {
        _context.GsTipoDispositivo.Update(tipoDispositivo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipoDispositivo = await _context.GsTipoDispositivo.FindAsync(id);
        if (tipoDispositivo != null)
        {
            _context.GsTipoDispositivo.Remove(tipoDispositivo);
            await _context.SaveChangesAsync();
        }
    }
}