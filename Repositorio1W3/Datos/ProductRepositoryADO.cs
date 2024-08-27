using Repositorio1W3.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio1W3.Datos
{
    public class ProductRepositoryADO : ProductoRepositoryADO
    {
        public bool Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetAll()
        {
            List<Producto> lista = new List<Producto>();
            var tabla = DataHelper.GetInstance().EjecutarSPQuery("SP_Recuperar_Productos");
            foreach (DataRow row in tabla.Rows)
            {
                Producto p = new Producto();
                p.Codigo = (int)row["codigo"];
                p.Nombre = row["n_producto"].ToString();
                p.Precio = (double)row["precio"];
                p.Stock = (int)row["stock"];
                p.Activo = (bool)row["esta_activo"];

                lista.Add(p);

            }
            return lista;
        }

        public Producto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
