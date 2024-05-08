using BE_Ventas.Repository.Entities;

namespace BE_Ventas.Repository.Interfaces
{
    public interface IProductoRepository
    {
        public Task<List<Common.Models.Producto>> ObtenerProductos();
        public Task<bool> CrearProducto(Common.Models.Producto producto);
        public Task<bool> BorrarProducto(int id);
        public Task<bool> ModificarProducto(Common.Models.Producto producto);
    }
}
