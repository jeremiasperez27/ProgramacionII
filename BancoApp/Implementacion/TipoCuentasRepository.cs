using BancoApp.Datos;
using BancoApp.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Implementacion
{
    public class TipoCuentasRepository : ITipoCuentasRepository
    {
        public List<TipoCuenta> GetAll()
        {
            List<TipoCuenta> lista= new List<TipoCuenta>();
            var tabla = DataHelper.GetInstance().EjecutarSPQuery("TIPO_CUENTAS");
            foreach(DataRow row in tabla.Rows)
            {
                TipoCuenta tp = new TipoCuenta();
                tp.Nombre = row["NOMBRE"].ToString();
            }

            return lista;   

        }
    }
}
