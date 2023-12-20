using ConsumirApiPruebaTecnica.Models;

namespace ConsumirApiPruebaTecnica.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<Producto>> GetProductosAsync();

        Task<IEnumerable<DetalleProducto>> GetDetallesAsync();

        Task<HttpResponseMessage> CreateProductoAsync(Producto producto);

        Task<HttpResponseMessage> CreateDetalleAsync(DetalleProducto detalle);

        Task<DetalleProducto> FindDetalleAsync(int id);
    }
}
