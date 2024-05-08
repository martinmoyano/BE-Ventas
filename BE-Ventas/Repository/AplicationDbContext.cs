using BE_Ventas.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE_Ventas.Repository
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Repository.Entities.Venta> Venta { get; set; }
        public DbSet<Repository.Entities.DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Repository.Entities.Cliente> Cliente { get; set; }
        public DbSet<Repository.Entities.Producto> Producto { get; set; }
    }
}
