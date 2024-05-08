using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ventas.Repository.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public List<DetalleVenta> DetalleVentaProducto { get; set; }
    }
}
