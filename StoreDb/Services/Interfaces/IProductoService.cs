using StoreDb.MODELS;
using StoreDb.RESPONSE;

namespace StoreDb.Services.Interfaces
{
    public interface IProductoService
    {
        public Task<Response> GetProductoByName(string name);
        public Task<Response> GetProductos();
    }
}
