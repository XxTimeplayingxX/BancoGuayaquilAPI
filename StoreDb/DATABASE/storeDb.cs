using StoreDb.RESPONSE;
using System.Data.SqlClient;

namespace StoreDb.DATABASE
{
    public class storeDb
    {
        private string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
        Response response = null;


        public Response DatabaseConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                response = new Response()
                {
                    code = ResponseType.Success,
                    message = "Conexión Exitosa",
                    data = connection
                };
            }
            catch (Exception ex)
            {
                return response = new Response()
                {
                    code = ResponseType.Error,
                    message = ex.Message,
                    data = ex.InnerException
                };
            }
            return response;

        }
    }
}
