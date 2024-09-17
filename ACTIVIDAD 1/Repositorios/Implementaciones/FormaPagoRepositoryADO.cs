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
    public class FormaPagoRepositoryADO: IFormaPagoRepository 
    {
        public List<FormaPago> GetAll()
        {
            DataTable tabla = DataHelper
                .GetInstance()
                .ExecuteSPQuery("SP_OBTENER_FORMAS_PAGO", null);
            var formasPago = new List<FormaPago>();

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    var formaPago = new FormaPago
                    {
                        Id = (int)row["ID"],
                        Nombre = row["NOMBRE"].ToString()
                    };
                    formasPago.Add(formaPago);
                }
            }

            return formasPago;
        }
    }
}
