using EcoVolt.Data;
using EcoVolt.Models;
using EcoVolt.Repositories;
using EcoVolt.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext com a conexão Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Registrar todos os repositórios
builder.Services.AddScoped<IGsBairroRepository, GsBairroRepository>();
builder.Services.AddScoped<IGsCidadeRepository, GsCidadeRepository>();
builder.Services.AddScoped<IGsConsumidorRepository, GsConsumidorRepository>();
builder.Services.AddScoped<IGsConsumoEnergiaRepository, GsConsumoEnergiaRepository>();
builder.Services.AddScoped<IGsDispositivoRepository, GsDispositivoRepository>();
builder.Services.AddScoped<IGsEstadoRepository, GsEstadoRepository>();
builder.Services.AddScoped<IGsFonteEnergiaRepository, GsFonteEnergiaRepository>();
builder.Services.AddScoped<IGsGeracaoEnergiaRepository, GsGeracaoEnergiaRepository>();
builder.Services.AddScoped<IGsLocalizacaoRepository, GsLocalizacaoRepository>();
builder.Services.AddScoped<IGsPaisRepository, GsPaisRepository>();
builder.Services.AddScoped<IGsTipoConsumidorRepository, GsTipoConsumidorRepository>();
builder.Services.AddScoped<IGsTipoDispositivoRepository, GsTipoDispositivoRepository>();
builder.Services.AddScoped<IGsTipoFonteRepository, GsTipoFonteRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();