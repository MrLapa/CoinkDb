using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataLayer.AccessDB
{
    public class AccessDataBase
    {
        private const string STRING_CONNECTION = @"Data Source=DESKTOP-Q5PDDPN;Initial Catalog=CoinkDb;User ID=SA;Password=123456";
        private static SqlConnection openConnection()
        {
            SqlConnection con = new SqlConnection(STRING_CONNECTION);
            con.Open();

            return con;
        }
        public static async Task<DataTable> ExecuteProcedureAsync(string procedureName)
        {
            SqlConnection connection = null;
            DataTable dtResult = null;
            try
            {
                connection = openConnection();
                SqlCommand cmd = new SqlCommand(procedureName)
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sdr = await cmd.ExecuteReaderAsync();
                dtResult = new DataTable("User");
                dtResult.Load(sdr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dtResult;
        }
    }
}
