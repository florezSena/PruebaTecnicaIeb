using System.ComponentModel.DataAnnotations;

namespace ConsumirApiPruebaTecnica.Models
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
