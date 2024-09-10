using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad1._5.Entidades
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public int FacuraId { get; set; }

        public FormaPago FormaPago { get; set; }
        public int Cliente { get; set; }
    }
}
