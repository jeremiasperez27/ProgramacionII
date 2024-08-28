using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Datos
{
    public class DataHelper
    {
        public static DataHelper _instance;
        private SqlConnection _connection;

        public DataHelper()
        {
            _connection= new SqlConnection(Properties.Resources.StrConnection);
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable EjecutarSPQuery(string sp)
        {
            DataTable tabla = new DataTable();
            try
            {
                _connection.Open();

                var comando = new SqlCommand(sp, _connection);
                comando.CommandType = CommandType.StoredProcedure;
                tabla.Load(comando.ExecuteReader());

                _connection.Close();
            }
            catch (SqlException)
            {
                //Gestionar error...
                tabla = null;
            }
            return tabla;
        }
    }
}
