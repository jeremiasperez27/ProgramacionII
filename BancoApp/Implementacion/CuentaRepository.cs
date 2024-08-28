using BancoApp.Datos;
using BancoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Implementacion
{
    public class CuentaRepository : ICuentaRepository
    {
        private SqlConnection _connection;

        public bool Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cuenta> GetAll()
        {
            List<Cuenta> lista = new List<Cuenta>();
            var tabla = DataHelper.GetInstance().EjecutarSPQuery("CUENTAS");
            foreach (DataRow row in tabla.Rows) 
            { 
                Cuenta c = new Cuenta();
                c.Cbu = (int)row["CBU"];
                c.Saldo = (int)row["SALDO"];
                c.tipoCuenta = (TipoCuenta)row["TIPO_CUENTA_ID"];
                c.UltimoMovimiento = (DateTime)row["ULTIMO_MOVIMIENTO"];
                c.Cliente = (Cliente)row["CLIENTE_ID"];
            }
            return lista;   
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Cuenta oCuenta)
        {
            bool result = true;
            string query = "CREAR_CUENTA";

            try
            {
                if(oCuenta != null) 
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CBU", oCuenta.Cbu);
                    cmd.Parameters.AddWithValue("SALDO", oCuenta.Saldo);
                    cmd.Parameters.AddWithValue("TIPO_CUENTA_ID", oCuenta.tipoCuenta);
                    cmd.Parameters.AddWithValue("ULTIMO_MOVIMIENTO", oCuenta.UltimoMovimiento);
                    cmd.Parameters.AddWithValue("CLIENTE_ID", oCuenta.Cliente);
                    result = cmd.ExecuteNonQuery() == 1;

                }

            }
            catch (SqlException sqlEx)
            {

                result = false;  
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
