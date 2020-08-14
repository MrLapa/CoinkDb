using System;
using System.Collections.Generic;
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
        public static async Task<DataTable> ExecuteProcedureQueryAsync(string procedureName, object classProperties)
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
                SqlParameter[] parameters = setParameters(classProperties);
                cmd.Parameters.AddRange(parameters);
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

        private static SqlParameter[] setParameters<T>(T classProperties)
        {
            var properties = classProperties.GetType().GetProperties();
            var parameters = new List<SqlParameter>();

            foreach (var prop in properties)
            {
                string type = prop.PropertyType.Name;
                if (type.Equals("Int32")
                    || type.Equals("String")
                    )
                {
                    parameters.Add(new SqlParameter("@" + prop.Name, prop.GetValue(classProperties)));
                }
            }

            return parameters.ToArray();
        }
    }
}
