using BE_Ventas.Common.Models;
using BE_Ventas.Repository.Entities;
using BE_Ventas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE_Ventas.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly AplicationDbContext _context;              

        public VentaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Common.Models.Venta>> ObtenerVentas()
        {
            List<Common.Models.Venta> _ventas = new();

            var ventasBD = _context.Venta.Include(x => x.DetalleVentas).ToList();//Hace el Join automático por los IDs.

            foreach (var item in ventasBD)
            {
                Common.Models.Venta venta = new()
                {
                    IdCliente = item.ClienteId,
                    IdVenta = item.IdVenta,
                    Fecha = item.Fecha
                };
                venta.DetalleVentas = new List<Common.Models.DetalleVenta>();

                foreach (var item2 in item.DetalleVentas)
                {
                    venta.DetalleVentas.Add(new Common.Models.DetalleVenta()
                    {
                        IdDetalleVenta= item2.IdDetalleVenta,
                        Precio = item2.Precio,
                        Cantidad= item2.Cantidad,
                        IdProducto = item2.ProductoId,
                        VentaIdVenta = item2.VentaIdVenta
                    });
                    venta.Total = venta.DetalleVentas.Sum(x => x.Cantidad * x.Precio);
                }
                _ventas.Add(venta);
            }

            return await Task.Run(() => _ventas); 
        }
                
        public async Task<bool> CrearVenta(Common.Models.Venta venta)
        {
            List<Repository.Entities.DetalleVenta> detalleVentaBD = new();

            foreach (var item in venta.DetalleVentas)
            {
                detalleVentaBD.Add(new Repository.Entities.DetalleVenta()
                {
                    IdDetalleVenta = item.IdDetalleVenta,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                    ProductoId = item.IdProducto,
                    VentaIdVenta = item.VentaIdVenta
                });
            }

            Repository.Entities.Venta ventaBD = new()
            {
                IdVenta = venta.IdVenta,
                ClienteId = venta.IdCliente,
                Fecha = venta.Fecha,
                DetalleVentas = detalleVentaBD
            };

            _context.Venta.Add(ventaBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }
    }
}
