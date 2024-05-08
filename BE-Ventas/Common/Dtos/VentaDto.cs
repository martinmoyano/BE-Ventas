using BE_Ventas.Repository.Entities;

namespace BE_Ventas.Common.Dtos
{
    public class VentaDto
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public List<Common.Models.DetalleVenta> DetalleVentas { get; set; }        
    }
}
