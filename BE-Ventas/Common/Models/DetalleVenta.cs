using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ventas.Common.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int VentaIdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; } 
    }
}
