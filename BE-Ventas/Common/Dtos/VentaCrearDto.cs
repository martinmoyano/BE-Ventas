namespace BE_Ventas.Common.Dtos
{
    public class VentaCrearDto
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<Common.Models.DetalleVenta> DetalleVentas { get; set; }
    }
}
