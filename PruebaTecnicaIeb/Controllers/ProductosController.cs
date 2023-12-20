using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaIeb.Models;

namespace PruebaTecnicaIeb.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : Controller
    {
        private readonly PruebaTecnicaContext _context;
        public ProductosController(PruebaTecnicaContext context)
        {
            _context = context;
        }
        //GET--------------------------------------------------
        [HttpGet(Name = "GetProductos")]
        public ActionResult<IEnumerable<Producto>> GetAll()//Metodo
        {
            return _context.Producto.ToList();//Devuelve la lista
        }
        [HttpGet("id")]
        public ActionResult<Producto> GetById(int id)
        {
            var product = _context.Producto.Find(id);//Devuelve 1 solo dato

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        //POST---------------------------------------------------------
        [HttpPost]
        public ActionResult<Producto> Create(Producto product)
        {
            _context.Producto.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = product.IdProducto }, product);
        }

    }
}
