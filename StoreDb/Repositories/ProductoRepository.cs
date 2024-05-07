using StoreDb.DATABASE;
using StoreDb.MODELS;
using StoreDb.Repositories.Interfaces;
using StoreDb.RESPONSE;
using System.Data.SqlClient;
using System.Data;

namespace StoreDb.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        public async Task<Response> GetProductoByName(string name)
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
                SqlCommand command = new("GetByName", connection);
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 50)).Value = name;

                command.CommandType = CommandType.StoredProcedure;
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

        public async Task<Response> GetProductos()
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
                SqlCommand command = new("GetAllProductos", connection);
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
