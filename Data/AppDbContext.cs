using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VendaLanches.Models;

namespace VendaLanches.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Lanche> Lanches { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Entrega> Entregas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    }

}