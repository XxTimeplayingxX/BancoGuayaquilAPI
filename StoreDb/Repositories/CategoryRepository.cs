using StoreDb.DATABASE;
using StoreDb.Repositories.Interfaces;
using StoreDb.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace StoreDb.Repositories
{
    public class CategoryRepository : ICategoriasRepository
    {
        public async Task<Response> GetCategorias()
        {
            storeDb storeDB = new storeDb();
            DataSet dataSet = new();
            SqlConnection connection = null;
            // Response
            Response response = null;
            response = storeDB.DatabaseConnection();

            if (response.code == ResponseType.Error)
            {
                return response;
            }
            connection = (SqlConnection)response.data;

            try
            {
                SqlCommand command = new("GetCategoria", connection);
                SqlDataAdapter dataAdapter = new(command);

                dataAdapter.Fill(dataSet);
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Successful response",
                    data = dataSet
                };
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }
            finally
            {
                if (connection.State > 0)
                {
                    await connection.CloseAsync();
                }
            }
            return response;
        }
    }
}
