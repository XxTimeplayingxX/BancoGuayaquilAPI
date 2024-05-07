using StoreDb.RESPONSE;

namespace StoreDb.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<Response> GetCategory();
    }
}
