using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaIeb.Models;

namespace PruebaTecnicaIeb.Controllers
{
    [ApiController]
    [Route("api/Detalles")]
    public class DetalleProductos : Controller
    {
        private readonly PruebaTecnicaContext _context;
        public DetalleProductos(PruebaTecnicaContext context)
        {
            _context = context;
        }
        //GET--------------------------------------------------
        [HttpGet(Name = "GetDetalles")]
        public ActionResult<IEnumerable<DetalleProducto>> GetAll()//Metodo
        {
            return _context.DetalleProducto.ToList();//Devuelve la lista
        }
        [HttpGet("id")]
        public ActionResult<DetalleProducto> GetById(int id)
        {
            var detail = _context.DetalleProducto
                .FirstOrDefault(d => d.IdProducto == id);

            if (detail == null)
            {
                return NotFound();
            }
            return detail;
        }
        //POST---------------------------------------------------------
        [HttpPost]
        public ActionResult<DetalleProducto> Create(DetalleProducto detail)
        {
            _context.DetalleProducto.Add(detail);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = detail.IdProducto }, detail);
        }

    }
}
