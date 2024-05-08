namespace BE_Ventas.Common.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }  
        
    }
}
