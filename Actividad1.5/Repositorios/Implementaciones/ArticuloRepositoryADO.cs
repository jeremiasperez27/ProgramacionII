using Actividad1._5.Entidades;
using Actividad1._5.Repositorios.Contratos;
using Actividad1._5.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Repositorios.Implementaciones
{
    public class ArticuloRepositoryADO : IArticuloRepository
    {
        public List<Articulo> GetAll()
        {
            DataTable tabla = DataHelper
               .GetInstance()
               .ExecuteSPQuery("SP_ARTICULOS", null);
            var articulos = new List<Articulo>();

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    var articulo = new Articulo
                    {
                        Id = (int)row["ID"],
                        Nombre = row["NOMBRE"].ToString(),
                        PrecioUnitario = Convert.ToInt32(row["PRECIO_UNITARIO"])
                    };
                    articulos.Add(articulo);
                }
            }

            return articulos;
        }
    }
}

