using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ventas.Common.Dtos
{
    public class DetalleVentaDto
    {
        public int IdDetalleVenta { get; set; }
        public int VentaIdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
