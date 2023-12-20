using ConsumirApiPruebaTecnica.Services;
using Microsoft.AspNetCore.Mvc;
using ConsumirApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumirApiPruebaTecnica.Controllers
{
    public class ProductosController : Controller
    {
        public readonly IApiClient _client;
        public ProductosController(IApiClient client)
        {
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _client.GetProductosAsync();
            return View(productos);
        }
        public async Task<IActionResult> Detalle(int id,string nombre,double precio,string descripcion)
        {
            try
            {
                var detalle = await _client.FindDetalleAsync(id);
                if (detalle != null)
                {
                    //encontramos el detalle podemos mandar los datos del producto y enviarlo a la vista
                    ViewBag.Nombre = nombre;
                    ViewBag.Precio = precio;
                    ViewBag.Descripcion = descripcion;
                    return View(detalle);

                }
                else
                {
                    return View("NotFound");
                }
            }
            catch (HttpRequestException ex)
            {
                TempData["ErrorMessage"] = "El producto seleccionado no tiene detalle";
                return RedirectToAction("Index");
            }
        }



        public IActionResult Create()
        {
            return View();
        }



        public async Task<IActionResult> RegistrarDetalle()
        {
            var productos = await _client.GetProductosAsync();
            return View(productos);
        }



        [HttpGet]
        public async Task<IActionResult> AlmacenarDetalles(DetalleProducto detalle)
        {
            Console.WriteLine($"Detalle recibido: {detalle.IdProducto}, {detalle.Cantidad}, {detalle.ValorIva}, {detalle.ValorTotal}");

            var detalles = await _client.GetDetallesAsync();

            bool idProductoExistente = false;

            foreach (var detalleExistente in detalles)
            {
                if (detalleExistente.IdProducto == detalle.IdProducto)
                {
                    // El IdProducto ya existe en los detalles almacenados
                    idProductoExistente = true;
                    break; // No es necesario seguir recorriendo la lista
                }
            }
            if (idProductoExistente)
            {
                // No crear el detalle ya que ya esta almacenado uno con ese producto
                return Json(new { success = false, message = "YaExiste" });
            }
            else
            {
                // El IdProducto no existe en los detalles almacenados, asi que lo almacenamos
                await _client.CreateDetalleAsync(detalle);
                return Json(new { success = true, message = "Creado" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var response = await _client.CreateProductoAsync(producto);

                if (response.IsSuccessStatusCode)
                {
                    // La solicitud POST fue exitosa
                    return RedirectToAction("Index");
                }
                else
                {
                    // La solicitud POST falló
                    ModelState.AddModelError(string.Empty, "Error en la creación del producto");
                    return View();
                }
            }
            return View();
        }
    }
}
