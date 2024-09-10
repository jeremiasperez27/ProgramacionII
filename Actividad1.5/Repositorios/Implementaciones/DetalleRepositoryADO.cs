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
    public class DetalleRepositoryADO : IDetalleRepository
    {
        public bool Add(DetalleFactura detalle)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("@ARTICULO_ID",detalle.ArticuloId),
                new ParameterSQL("@CANTIDAD",detalle.Cantidad),
                new ParameterSQL("@PRECIO",detalle.Precio),
                new ParameterSQL("@FACTURA_ID",detalle.FacuraId),
                new ParameterSQL("@FORMA_PAGO_ID",detalle.FormaPago),
                new ParameterSQL("@CLIENTE_ID",detalle.Cliente)
            };

            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("SP_CREAR_DETALLE", parametros);

            return filasAfectadas > 0;
        }

        public List<DetalleFactura> Get()
        {
            var detalles = new List<DetalleFactura>();
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_DETALLE", null);
            if (tabla != null)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    var detalle = new DetalleFactura
                    {

                        Id = (int)row["ID"],
                        ArticuloId = (int)row["ARTICULO_ID"],
                        Cantidad = (int)row["CANTIDAD"],
                        Precio = (int)row["PRECIO"],
                        FacuraId = (int)row["FACTURA_ID"],
                        FormaPago = new FormaPago
                        {
                            Id = (int)row["FORMA_PAGO_ID"],
                            Nombre = row["FORMA_PAGO_NOMBRE"].ToString()
                        },
                        Cliente = (int)row["CLIENTE_ID"]
                    };
                    detalles.Add(detalle);
                }
            }

            return detalles;
        }

        public bool Update(DetalleFactura detalle)
        {
            var parametros = new List<ParameterSQL>
            {
                new ParameterSQL("@ID",detalle.Id),
                new ParameterSQL("@ARTICULO_ID",detalle.ArticuloId),
                new ParameterSQL("@CANTIDAD",detalle.Cantidad),
                new ParameterSQL("@PRECIO",detalle.Precio),
                new ParameterSQL("@FACTURA_ID",detalle.FacuraId),
                new ParameterSQL("@FORMA_PAGO_ID",detalle.FormaPago),
                new ParameterSQL("@CLIENTE_ID",detalle.Cliente)
            };

            int filasAfectadas = DataHelper.GetInstance().ExecuteSPDML("SP_ACTUALIZAR_DETALLE", parametros);
            return filasAfectadas > 0;
        }
    }
}
