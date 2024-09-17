using Articulo_WebApi.Entities;
using Articulo_WebApi.Utilities;
using System.Data;

namespace Articulo_WebApi.Data
{
    public class ArticuloRepository : IArticuloRepository
    {
        public bool AgregarEditarArticulo(Articulo articulo)
        {
            var parametros = new List<ParameterSQL>
                {
                   new ParameterSQL("@NOMBRE",articulo.Nombre),
                   new ParameterSQL("@PRECIO_UNITARIO",articulo.PrecioUnitario)
                    
                };

            int filasAfectadas = DataHelper
                .GetInstance()
                .ExecuteSPDML("SP_AGREGAR_ARTICULO", parametros);

            return filasAfectadas > 0;
        }

        public bool BorrarArticulo(int codigo)
        {
            var parametros = new List<ParameterSQL>
                {
                    new ParameterSQL("@ID", codigo)
                };

            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("SP_ELIMINAR_ARTICULO", parametros);
            return filasAfectadas > 0;
        }

        public List<Articulo> ObtenerArticulos()
        {
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_ARTICULOS",null);
            List<Articulo> lista = new List<Articulo>();

            foreach (DataRow row in tabla.Rows)
            {
                int codigo = int.Parse(row["ID"].ToString());
                string nombre = row["NOMBRE"].ToString();
                float precio = Convert.ToInt32(row["PRECIO_UNITARIO"]);
                Articulo a = new Articulo(codigo, nombre, precio);
                lista.Add(a);
            }

            return lista;
        }
    }
}
