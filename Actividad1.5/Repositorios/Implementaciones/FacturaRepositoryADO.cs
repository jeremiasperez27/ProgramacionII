using Actividad1._5.Entidades;
using Actividad1._5.Repositorios.Contratos;
using Actividad1._5.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Repositorios.Implementaciones
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        public bool Add(Factura oFactura)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_CREAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                //parametro de entrada
                cmd.Parameters.AddWithValue("@NRO_FACTURA", oFactura.NroFactura);
                cmd.Parameters.AddWithValue("@FECHA", oFactura.Fecha);

                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int idCliente = (int)param.Value;
                if (oFactura.Detalles.Count == 0)
                {
                    t.Rollback();
                }
                foreach (var detalle in oFactura.Detalles)
                {
                    var cmdDetalle = new SqlCommand("SP_AGREGAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@ID", detalle.Id);
                    cmdDetalle.Parameters.AddWithValue("@ARTICULO_ID", detalle.ArticuloId);
                    cmdDetalle.Parameters.AddWithValue("@CANTIDAD", detalle.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@PRECIO", detalle.Precio);
                    cmdDetalle.Parameters.AddWithValue("@FACTURA_ID", oFactura.Id);
                    cmdDetalle.Parameters.AddWithValue("@FORMA_PAGO_ID", detalle.FormaPago.Id);
                    cmdDetalle.Parameters.AddWithValue("@CLIENTE_ID", idCliente);
                    cmdDetalle.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }

        public List<Factura> GetAll()
        {
            var facturas = new List<Factura>();
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_FACTURAS", null);
            if (tabla != null)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    Factura factura = new Factura()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        NroFactura = Convert.ToInt32(row["NRO_FACTURA"]),
                        Fecha = Convert.ToDateTime(row["FECHA"]),

                    };
                    facturas.Add(factura);

                }
            }

            return facturas;
        }
    }
}
