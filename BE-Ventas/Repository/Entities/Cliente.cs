using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Ventas.Repository.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public List<Venta> VentaCliente { get; set; }

    }
}
