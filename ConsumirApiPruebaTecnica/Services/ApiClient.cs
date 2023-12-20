using ConsumirApiPruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsumirApiPruebaTecnica.Services
{
    public class ApiClient:IApiClient
    {
        private readonly HttpClient _httpClient;
        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7268/api/");
        }
        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("Productos");
            return response;
        }
        public async Task<IEnumerable<DetalleProducto>> GetDetallesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<DetalleProducto>>("Detalles");
            return response;
        }
        public async Task<HttpResponseMessage> CreateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PostAsJsonAsync("Productos", producto);
            return response;
        }
        public async Task<HttpResponseMessage> CreateDetalleAsync(DetalleProducto detalle)
        {
            var response = await _httpClient.PostAsJsonAsync("Detalles", detalle);
            return response;
        }
        public async Task<DetalleProducto> FindDetalleAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<DetalleProducto>($"Detalles/id?id={id}");
            return response;
        }
    }
}
