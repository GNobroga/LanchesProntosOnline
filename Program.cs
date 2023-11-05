using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendaLanches.Data;
using VendaLanches.Repositories;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.Services;
using VendaLanches.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => {
    var appConnection = builder.Configuration.GetConnectionString("AppConnection");
    options.UseNpgsql(appConnection);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepositoryImpl>();
builder.Services.AddScoped<ILancheRepository, LancheRepositoryImpl>();
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepositoryImpl>();
builder.Services.AddScoped<IEntregaRepository, EntregaRepositoryImpl>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitialImpl>();
// Session config
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseSession(); // Add session middleware.

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Allow use services to start application
using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var seedService = service.GetRequiredService<ISeedUserRoleInitial>();
seedService.SeedRoles();
seedService.SeedUsers();


app.Run();


