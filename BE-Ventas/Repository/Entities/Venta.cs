using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ventas.Repository.Entities
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdVenta { get; set; }        
        [ForeignKey("IdCliente")]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }
         
    }
}
