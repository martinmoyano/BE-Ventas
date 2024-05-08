using BE_Ventas.Common.Dtos;

namespace BE_Ventas.Services.Interfaces
{
    public interface IProductoServices
    {
        public Task<List<ProductoDto>> ObtenerProductos();
        public Task<bool> CrearProducto(ProductoDto productoDto);
        public Task<bool> BorrarProducto(int id);
        public Task<bool> ModificarProducto(ProductoDto productoDto);
    }
}
