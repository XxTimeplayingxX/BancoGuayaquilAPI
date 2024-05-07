using StoreDb.MODELS;
using StoreDb.Repositories.Interfaces;
using StoreDb.RESPONSE;
using StoreDb.Services.Interfaces;
using System.Data;

namespace StoreDb.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoriasRepository _categoryRepository;
        public CategoryService(ICategoriasRepository categoriasRepository)
        {
            _categoryRepository = categoriasRepository;
        }

        public async Task<Response> GetCategory()
        {
            Response Response = new Response();
            try
            {
                List<Categoria> CategoriaList = new();
                Response = await _categoryRepository.GetCategorias();
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Categoria categoria = new Categoria();

                        categoria.ID = int.Parse(rows["ID"].ToString());
                        categoria.Nombre = rows["nombre"].ToString();
                        CategoriaList.Add(categoria);
                    }
                }
                Response.data = CategoriaList;
            }
            catch (Exception ex)
            {
                Response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }

            return Response;
        }
    }
}
