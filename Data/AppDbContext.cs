using System.Configuration;
using Microsoft.EntityFrameworkCore;
using VendaLanches.Models;

namespace VendaLanches.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Lanche> Lanches { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Entrega> Entregas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected sealed override void OnModelCreating(ModelBuilder modelBuilder) {}
    }

}