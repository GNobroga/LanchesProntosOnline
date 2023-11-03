using Microsoft.EntityFrameworkCore;
using VendaLanches.Data;
using VendaLanches.Repositories;
using VendaLanches.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => {
    var appConnection = builder.Configuration.GetConnectionString("AppConnection");
    options.UseNpgsql(appConnection);
});

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepositoryImpl>();
builder.Services.AddScoped<ILancheRepository, LancheRepositoryImpl>();
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepositoryImpl>();
builder.Services.AddScoped<IEntregaRepository, EntregaRepositoryImpl>();


// Session config
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseSession(); // Add session middleware.

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
