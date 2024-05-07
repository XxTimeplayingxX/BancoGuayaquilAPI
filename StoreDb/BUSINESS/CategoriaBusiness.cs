using StoreDb.MAPPING;
using StoreDb.MODELS;
using StoreDb.RESPONSE;
using System.Data;

namespace StoreDb.BUSINESS
{
    public class CategoriaBusiness
    {
        public class BusinessLogicCategoria
        {
            CategoriaMapping categoria = new CategoriaMapping();
            Response Response = null;
            
            public async Task<Response> LlamarAMappingCategoriaByName(string name)
            {
                try
                {
                    List<Categoria> CategoriaList = new();
                    Response = await categoria.GetCategoriaByNameMapping(name);
                    if (Response.code == ResponseType.Success)
                    {
                        var dataSet = (DataSet)Response.data;
                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            Response = new Response()
                            {
                                code = ResponseType.Error,
                                message = "Error, valor no encontrado",
                                data = "Error, valor no encontrado"
                            };
                        }
                        else
                        {
                            foreach (DataRow rows in dataSet.Tables[0].Rows)
                            {
                                Categoria categoria = new Categoria();

                                categoria.ID = int.Parse(rows["ID"].ToString());
                                categoria.Nombre = rows["nombre"].ToString();
                                CategoriaList.Add(categoria);
                            }
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
}
