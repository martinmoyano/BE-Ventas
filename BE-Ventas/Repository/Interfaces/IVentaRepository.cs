

namespace BE_Ventas.Repository.Interfaces
{
    public interface IVentaRepository
    {        
        public Task<List<Common.Models.Venta>> ObtenerVentas();
        public Task<bool> CrearVenta(Common.Models.Venta venta);        
    }
}
