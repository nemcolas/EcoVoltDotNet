using EcoVolt.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GsPais>().ToTable("gs_pais");
        modelBuilder.Entity<GsEstado>().ToTable("gs_estado");
        modelBuilder.Entity<GsCidade>().ToTable("gs_cidade");
        modelBuilder.Entity<GsBairro>().ToTable("gs_bairro");
        modelBuilder.Entity<GsLocalizacao>().ToTable("gs_localizacao");
        modelBuilder.Entity<GsConsumidor>().ToTable("gs_consumidor");
        modelBuilder.Entity<GsConsumoEnergia>().ToTable("gs_consumo_energia");
        modelBuilder.Entity<GsFonteEnergia>().ToTable("gs_fonte_energia");
        modelBuilder.Entity<GsGeracaoEnergia>().ToTable("gs_geracao_energia");
        modelBuilder.Entity<GsTipoConsumidor>().ToTable("gs_tipo_consumidor");
        modelBuilder.Entity<GsTipoFonte>().ToTable("gs_tipo_fonte");
        modelBuilder.Entity<GsDispositivo>().ToTable("gs_dispositivo");
        modelBuilder.Entity<GsTipoDispositivo>().ToTable("gs_tipo_dispositivo");
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