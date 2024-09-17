using System.Data;
using System.Data.SqlClient;

namespace Articulo_WebApi.Utilities
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection("Data Source=JEREMIAS\\SQLEXPRESS;Initial Catalog=FACTURACION_COMERCIODB;Integrated Security=True");
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
                _instancia = new DataHelper();

            return _instancia;
        }

        public DataTable ExecuteSPQuery(string sp, List<ParameterSQL>? parametros)
        {
            DataTable t = new DataTable();
            SqlCommand cmd = null;

            try
            {
                _connection.Open();
                cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
            }
            catch (SqlException)
            {
                t = null;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return t;
        }



        public int ExecuteSPDML(string sp, List<ParameterSQL>? parametros)
        {
            int rows;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }

            return rows;
        }
        public SqlConnection GetConnection()
        {
            return _connection;
        }

    }
}
