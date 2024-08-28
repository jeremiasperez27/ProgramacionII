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
    public class ClienteRepository : IClienteRepository
    {
        public List<Cliente> GetAll()
        {
            List<Cliente> lista = new List<Cliente>();
            var tabla = DataHelper.GetInstance().EjecutarSPQuery("OBTENER_CLIENTES");
            foreach (DataRow row in tabla.Rows)
            {
                Cliente cli = new Cliente();
                cli.Nombre = row["NOMBRE"].ToString();
                cli.Apellido = row["APELLIDO"].ToString();
                cli.Dni = (int)row["DNI"];
            }


            return lista;
        }
    }

    
}
