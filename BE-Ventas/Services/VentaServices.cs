using BE_Ventas.Common.Dtos;
using BE_Ventas.Common.Models;
using BE_Ventas.Repository.Entities;
using BE_Ventas.Repository.Interfaces;
using BE_Ventas.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BE_Ventas.Services
{
    public class VentaServices : IVentaServices
    {
        private readonly IVentaRepository _iVentaRepository;                 

        public VentaServices(IVentaRepository iVentaRepository)
        {
            _iVentaRepository = iVentaRepository;
        }
        
        public async Task<List<VentaDto>> ObtenerVentas()
        {
            List<Common.Models.Venta> _ventas = await _iVentaRepository.ObtenerVentas().ConfigureAwait(false);

            List<VentaDto> ventasDto = new();

            _ventas.ToList().ForEach(x => ventasDto.Add(new VentaDto()
            {
                IdVenta = x.IdVenta,
                IdCliente = x.IdCliente,
                Fecha = x.Fecha,
                Total = x.Total,
                DetalleVentas = x.DetalleVentas
            }));

            return await Task.Run(() => ventasDto);
        }

        public async Task<bool> CrearVenta(VentaCrearDto ventaDto)
        {
            Common.Models.Venta venta = new()
            {
                IdVenta = ventaDto.IdVenta,
                IdCliente = ventaDto.IdCliente,
                Fecha = ventaDto.Fecha,
                DetalleVentas = ventaDto.DetalleVentas
            };

            return await _iVentaRepository.CrearVenta(venta);
        }
    }
}
