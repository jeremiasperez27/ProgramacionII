using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
    }
}
