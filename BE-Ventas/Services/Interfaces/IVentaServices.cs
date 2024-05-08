using BE_Ventas.Common.Dtos;

namespace BE_Ventas.Services.Interfaces
{
    public interface IVentaServices
    {
        public Task<List<VentaDto>> ObtenerVentas();
        public Task<bool> CrearVenta(VentaCrearDto ventaDto);        
    }
}
