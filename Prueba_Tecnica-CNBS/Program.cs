using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_CNBS.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de la base de datos
builder.Services.AddDbContext<DeclaracionesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

// Configurar HttpClient para ApiService y agregar ApiService como servicio
builder.Services.AddHttpClient<ApiService>(client =>
{
    // Configuración adicional para el cliente, si es necesaria
    client.DefaultRequestHeaders.Add("ApiKey", builder.Configuration["ApiKey"]);
});

// Para permitir la inyección de IConfiguration en ApiService
builder.Services.AddSingleton(builder.Configuration);

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
