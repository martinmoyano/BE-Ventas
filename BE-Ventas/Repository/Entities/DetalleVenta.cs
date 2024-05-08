using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_Ventas.Repository.Entities
{
    public class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleVenta { get; set; }
        [ForeignKey("IdVenta")]
        public int VentaIdVenta { get; set; }
        [ForeignKey("IdProducto")]
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
         
    }
}
