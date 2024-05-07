using StoreDb.RESPONSE;

namespace StoreDb.Repositories.Interfaces
{
    public interface ICategoriasRepository
    {
        public Task<Response> GetCategorias();
    }
}
