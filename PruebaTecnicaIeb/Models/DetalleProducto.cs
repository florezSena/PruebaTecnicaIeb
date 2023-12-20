using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaIeb.Models
{
    public partial class DetalleProducto
    {
        [Key]
        public int IdDetalleProducto { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double ValorTotal { get; set; }
        public double ValorIva { get; set; }
    }
}
