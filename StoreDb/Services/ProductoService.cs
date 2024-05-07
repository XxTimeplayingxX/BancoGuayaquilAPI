using StoreDb.MODELS;
using StoreDb.Repositories.Interfaces;
using StoreDb.RESPONSE;
using StoreDb.Services.Interfaces;
using System.Data;

namespace StoreDb.Services
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository _productoRepository; 
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<Response> GetProductoByName(string name)
        {
            Response Response = new Response();
            try
            {
                List<Producto> productosList = new();
                Response = await _productoRepository.GetProductoByName(name);
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
                            Producto producto = new Producto();
                            producto.Nombre = rows["Nombre"].ToString();
                            producto.Descripcion = rows["Descripción"].ToString();
                            producto.Precio = float.Parse(rows["Precio"].ToString());
                            producto.Imagen = rows["imagen"].ToString();
                            producto.Rating = rows["Rating"].ToString();
                            producto.Categoria_id = int.Parse(rows["Categoria_id"].ToString());
                            productosList.Add(producto);
                        }
                    }
                }
                Response.data = productosList;
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

        public async Task<Response> GetProductos()
        {
            Response Response = new Response();
            try
            {
                List<Producto> productosList = new();
                Response = await _productoRepository.GetProductos();
                if (Response.code == ResponseType.Success)
                {
                    var dataSet = (DataSet)Response.data;
                    foreach (DataRow rows in dataSet.Tables[0].Rows)
                    {
                        Producto producto = new Producto();
                        producto.ID = int.Parse(rows["id"].ToString());
                        producto.Nombre = rows["Nombre"].ToString();
                        producto.Descripcion = rows["Descripción"].ToString();
                        producto.Precio = float.Parse(rows["Precio"].ToString());
                        producto.Imagen = rows["imagen"].ToString();
                        producto.Rating = rows["Rating"].ToString();
                        producto.Categoria_id = int.Parse(rows["Categoria_id"].ToString());
                        productosList.Add(producto);
                    }
                }
                Response.data = productosList;
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
