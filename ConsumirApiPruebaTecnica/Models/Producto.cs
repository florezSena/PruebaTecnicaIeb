using System.ComponentModel.DataAnnotations;

namespace ConsumirApiPruebaTecnica.Models
{
    public partial class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }
    }
}
