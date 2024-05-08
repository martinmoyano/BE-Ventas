using BE_Ventas.Repository.Entities;
using BE_Ventas.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Ventas.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AplicationDbContext _context;

        public ProductoRepository(AplicationDbContext context) 
        {
            _context = context;  
        }

        public async Task<List<Common.Models.Producto>> ObtenerProductos()
        {
            var lista = _context.Producto.Select(x => x);
            List<Common.Models.Producto> _productos = new();

            lista.ToList().ForEach(x => _productos.Add(new Common.Models.Producto()
            {
                IdProducto = x.IdProducto,
                Nombre = x.Nombre,
                Stock = x.Stock,
                Precio = x.Precio
            }));                        

            return await Task.Run(() => _productos);
        }

        public async Task<bool> CrearProducto(Common.Models.Producto producto)
        {
            Producto productoBD = new()
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            _context.Producto.Add(productoBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> BorrarProducto(int id)
        {
            var producto = _context.Producto.Where(prod => prod.IdProducto == id);

            foreach (var item in producto)
            {
                _context.Producto.Remove(item);
            }

            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> ModificarProducto(Common.Models.Producto producto)
        {
            Repository.Entities.Producto productoBD = new()
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };

            _context.Producto.Update(productoBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }
    }
}
