using EcoVolt.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoVolt.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GsPais>().ToTable("GS_PAIS");
        modelBuilder.Entity<GsEstado>().ToTable("GS_ESTADO");
        modelBuilder.Entity<GsCidade>().ToTable("GS_CIDADE");
        modelBuilder.Entity<GsBairro>().ToTable("GS_BAIRRO");
        modelBuilder.Entity<GsLocalizacao>().ToTable("GS_LOCALIZACAO");
        modelBuilder.Entity<GsConsumidor>().ToTable("GS_CONSUMIDOR");
        modelBuilder.Entity<GsConsumoEnergia>().ToTable("GS_CONSUMO_ENERGIA");
        modelBuilder.Entity<GsFonteEnergia>().ToTable("GS_FONTE_ENERGIA");
        modelBuilder.Entity<GsGeracaoEnergia>().ToTable("GS_GERACAO_ENERGIA");
        modelBuilder.Entity<GsTipoConsumidor>().ToTable("GS_TIPO_CONSUMIDOR");
        modelBuilder.Entity<GsTipoFonte>().ToTable("GS_TIPO_FONTE");
        modelBuilder.Entity<GsDispositivo>().ToTable("GS_DISPOSITIVO");
        modelBuilder.Entity<GsTipoDispositivo>().ToTable("GS_TIPO_DISPOSITIVO");
    }

    public DbSet<GsPais> GsPais { get; set; }
    public DbSet<GsEstado> GsEstado { get; set; }
    public DbSet<GsCidade> GsCidade { get; set; }
    public DbSet<GsBairro> GsBairro { get; set; }
    public DbSet<GsLocalizacao> GsLocalizacao { get; set; }
    public DbSet<GsConsumidor> GsConsumidor { get; set; }
    public DbSet<GsConsumoEnergia> GsConsumoEnergia { get; set; }
    public DbSet<GsFonteEnergia> GsFonteEnergia { get; set; }
    public DbSet<GsGeracaoEnergia> GsGeracaoEnergia { get; set; }
    public DbSet<GsTipoConsumidor> GsTipoConsumidor { get; set; }
    public DbSet<GsTipoFonte> GsTipoFonte { get; set; }
    public DbSet<GsDispositivo> GsDispositivo { get; set; }
    public DbSet<GsTipoDispositivo> GsTipoDispositivo { get; set; }
}