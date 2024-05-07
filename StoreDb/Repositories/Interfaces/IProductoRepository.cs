using StoreDb.MODELS;
using StoreDb.RESPONSE;

namespace StoreDb.Repositories.Interfaces
{
    public interface IProductoRepository 
    {
        public Task<Response> GetProductoByName(string name);
        public Task<Response> GetProductos();
    }
}
