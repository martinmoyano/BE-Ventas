using BE_Ventas.Common.Dtos;
using BE_Ventas.Repository.Entities;
using BE_Ventas.Repository.Interfaces;
using BE_Ventas.Services.Interfaces;

namespace BE_Ventas.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly IProductoRepository _iProductoRepository;

        public ProductoServices(IProductoRepository iProductoRepository)
        {
            _iProductoRepository = iProductoRepository; 
        }

        public async Task<List<ProductoDto>> ObtenerProductos()
        {
            List<ProductoDto> _productosDto = new();
            List<Common.Models.Producto> _productos = await _iProductoRepository.ObtenerProductos().ConfigureAwait(false);

            _productos.ToList().ForEach(x => _productosDto.Add(new ProductoDto()
            {
                IdProducto = x.IdProducto,
                Nombre = x.Nombre,
                Stock = x.Stock,
                Precio = x.Precio
            }));

            return await Task.Run(() => _productosDto);            
        }

        public async Task<bool> CrearProducto(ProductoDto productoDto)
        {
            Common.Models.Producto producto = new()
            {
                IdProducto = productoDto.IdProducto,
                Nombre = productoDto.Nombre,
                Stock = productoDto.Stock,
                Precio = productoDto.Precio
            };

            return await _iProductoRepository.CrearProducto(producto);
        }

        public async Task<bool> BorrarProducto(int id)
        {
            return await Task.Run(() => _iProductoRepository.BorrarProducto(id));
        }

        public async Task<bool> ModificarProducto(ProductoDto productoDto)
        {
            Common.Models.Producto producto = new()
            {
                IdProducto = productoDto.IdProducto,
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock
            };

            return await Task.Run(() => _iProductoRepository.ModificarProducto(producto));
        }
    }
}
